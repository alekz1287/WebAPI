using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HillmanMVC2.Services;
using HillmanMVC2.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HillmanMVC2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            services.AddMvc();

            var apiURL = Configuration["apiURL"];
            services.AddScoped<IActiveDirectoryClient>(x => new ActiveDirectoryClient(apiURL));    //Scoped = created once per request
            services.AddScoped<IConcurClient>(x => new ConcurClient(apiURL));    //Scoped = created once per request
            services.AddScoped<IIntegrationClient>(x => new IntegrationClient(apiURL));    //Scoped = created once per request
            services.AddScoped<IJDEdwardsClient>(x => new JDEdwardsClient(apiURL));    //Scoped = created once per request


            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hillman API V1");
                //c.RoutePrefix = string.Empty;   //Display swagger on "home page"
            });
        }
    }
}
