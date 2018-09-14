using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using FluentValidation.AspNetCore;
using IBM.EntityFrameworkCore;
using IBM.EntityFrameworkCore.Storage.Internal;
using HillmanGroup.API.Models.JDEEntities;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Server.IISIntegration;

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
            string mode = "Dev";// "Production"; - NOT READY FOR PRIME TIME!
#if DEBUG
            mode = "Dev";
#endif
            //Choose configuration values based on Debug/Release mode
            string concurEntityId = Configuration[$"Concur:{mode}:EntityId"];
            string outboundDirectory = Configuration[$"Concur:{mode}:OutboundDirectory"];
            string inboundDirectory = Configuration[$"Concur:{mode}:InboundDirectory"];
            string receivedDirectory = Configuration[$"Concur:{mode}:ReceivedDirectory"];
            string vlTraderUserName = Configuration[$"Concur:VlTrader:UserName"];
            string vlTraderPassword = Configuration[$"Concur:VlTrader:Password"];
            string connectionString = Configuration[$"ConnectionStrings:{mode}"];    //Store this sensitive data in the WINDOWS ENVIRONMENT VARIABLES FOR PRODUCTION

            //Configure the services/repos
            services.AddScoped<Services.IConcurRepository>(x => new
                Services.ConcurRepository(
                    concurEntityId,
                    outboundDirectory,
                    inboundDirectory,
                    receivedDirectory,
                    vlTraderUserName,
                    vlTraderPassword)
            );
            services.AddScoped<Services.IJDEdwardsRepository, Services.JDEdwardsRepository>();    //Scoped = created once per request
            services.AddScoped<Services.IActiveDirectoryService>(x => new Services.ActiveDirectoryService(Configuration));

            services.AddMvc()
                    .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Models.Concur.Employee300_Validator>());


            //Inject the JDEdwards DBContext for the Repository Service
            services.AddDbContext<JDEContext>(o =>
                o.UseDb2(connectionString,
                    p =>
                    {
                        p.SetServerInfo(IBMDBServerType.AS400);
                        p.UseRowNumberForPaging();
                    }
                )
            );
            
            //Enable Swagger
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
                c.AddFluentValidationRules();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseAuthentication();  //Comment to disable authorization
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            app.UseStatusCodePages();   //Return 200's, 300's, etc.

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hillman API V1");
                c.RoutePrefix = string.Empty;   //Display swagger on "home page"
            });

            //Configure AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.Shared.Employee, Models.Concur._300_EmployeeRecord>();
                cfg.CreateMap<Models.Shared.Employee, Models.Concur._305_EnhancedEmployeeRecord>();
            });            
        }
    }
}
