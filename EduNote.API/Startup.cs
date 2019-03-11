using AutoMapper;
using EduNote.API.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;

namespace EduNote.API
{
    public class Startup
    {
        private Container container = new Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            services.AddDbContext<EduNoteContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("EduNoteDatabase")));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "{yourAuthorizationServerAddress}";
                    options.Audience = "{yourAudience}";
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "EduNote API",
                    Description = "A simple ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "EduNote",
                        Email = string.Empty,
                        Url = string.Empty
                    },
                    License = new License
                    {
                        Name = "Use under MIT",
                        Url = "https://opensource.org/licenses/MIT"
                    }
                });
            });

            // Default lifestyle scoped + async
            // The recommendation is to use AsyncScopedLifestyle in for applications that solely consist of a Web API(or other asynchronous technologies such as ASP.NET Core)
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register services
            //cont  ainer.Register<IHelloWorldService, HelloWorldService>(Lifestyle.Scoped); // lifestyle can set here, sometimes you want to change the default lifestyle like singleton exeptionally

            // Register controllers DI resolution
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            // Wrap AspNet requests into Simpleinjector's scoped lifestyle
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EduNote API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();

            container.RegisterMvcControllers(app);

            // Verify Simple Injector configuration
            container.Verify();
        }
    }
}
