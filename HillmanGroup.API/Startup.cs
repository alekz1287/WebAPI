using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HillmanGroup.API.Entities;

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
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
            //.AddJsonOptions(o => //By default this changes property names to camelCase when returned as JSON
            //{
            //    if(o.SerializerSettings.ContractResolver != null) //This overrides the camelCase setting to preserve the capitalization as it appears in the model
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            //});
#if DEBUG
            services.AddTransient<Services.IMailService, Services.LocalMailService>();
#else
            services.AddTransient<Services.IMailService, Services.CloudMailService>();
#endif
            var connectionString = Configuration["ConnectionStrings:DefaultConnection"];    //Store this sensitive data in the WINDOWS ENVIRONMENT VARIABLES FOR PRODUCTION
            services.AddDbContext<CityInfoContext>(o => o.UseSqlServer(connectionString)); 

            services.AddScoped<Services.ICityInfoRepository, Services.CityInfoRepository>();    //Scoped = created once per request
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CityInfoContext cityInfoContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            //loggerFactory.AddProvider(new NLog.Extensions.Logging.NLogLoggerProvider());
            //loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            cityInfoContext.EnsureSeedDataForContext();
            app.UseStatusCodePages();   //Return 200's, 300's, etc.
            
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


        }
    }
}
