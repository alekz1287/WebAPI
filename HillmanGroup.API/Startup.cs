using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HillmanGroup.API.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore;
using FluentValidation.AspNetCore;
using System.Collections.Generic;

namespace HillmanGroup.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddAzureAdBearer(options => Configuration.Bind("AzureAd", options));

            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Models.PointOfInterestForCreationDTO_Validator>());
         
            var connectionString = Configuration["ConnectionStrings:AzureConnection"];    //Store this sensitive data in the WINDOWS ENVIRONMENT VARIABLES FOR PRODUCTION
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<Services.ICityInfoRepository, Services.CityInfoRepository>();    //Scoped = created once per request

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Hillman API",
                    Version = "v1",
                    Description = "JDE to Concur and back",
                    Contact = new Contact
                    {
                        Name = "Alex Kellerman",
                        Email = "alex.kellerman@pinnsg.com"
                    },
                });
                // Define the OAuth2.0 scheme that's in use (i.e. Implicit Flow)
                //c.AddSecurityDefinition("oauth2", new OAuth2Scheme
                //{
                //    Type = "oauth2",
                //    Flow = "implicit",
                //    AuthorizationUrl = "http://petstore.swagger.io/oauth/dialog",
                //    Scopes = new Dictionary<string, string>
                //    {
                //        { "readAccess", "Access read operations" },
                //        { "writeAccess", "Access write operations" }
                //    }
                //});
                //c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                //{
                //    { "oauth2", new[] { "readAccess", "writeAccess" } }
                //});
                c.AddFluentValidationRules();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoContext cityInfoContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //cityInfoContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();   //Return 200's, 300's, etc.

            //app.UseAuthentication();  //Comment to disable authorization
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDTO>();
                cfg.CreateMap<Entities.City, Models.CityDTO>();
                cfg.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDTO>();
                cfg.CreateMap<Models.PointOfInterestForCreationDTO, Entities.PointOfInterest>();
                cfg.CreateMap<Models.PointOfInterestForUpdateDTO, PointOfInterest>();
                cfg.CreateMap<PointOfInterest, Models.PointOfInterestForUpdateDTO>();

            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hillman API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
