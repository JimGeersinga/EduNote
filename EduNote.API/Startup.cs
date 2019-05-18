using AutoMapper;
using EduNote.API.EF;
using EduNote.API.Helpers;
using EduNote.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Text;

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
            services.AddCors();

            services.AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(
                   options =>
                   {
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                       options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   }
               );

            services.AddAutoMapper();

            services.AddDbContext<EduNoteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EduNoteDatabase"), b => b.MigrationsAssembly("EduNote.API")));



            // configure strongly typed settings objects
            IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            AppSettings appSettings = appSettingsSection.Get<AppSettings>();
            byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "V1.1",
                    Title = "EduNote API",
                    Description = "Documentation for the Edunote system.",
                    Contact = new Contact() { Name = "Jim Geersinga", Email = "j.geersinga@outlook.com" }
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"\n Please insert JWT with Bearer into field.",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>()
                {
                  { "Bearer", new string[]{ } }
                });
                //string filePath = Path.Combine(System.AppContext.BaseDirectory, "WebApi.xml");
                //c.IncludeXmlComments(filePath);
                c.DescribeAllEnumsAsStrings();
            });

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);
            services.EnableSimpleInjectorCrossWiring(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            container.RegisterMvcControllers(app);

            DbContextOptionsBuilder<EduNoteContext> builder = new DbContextOptionsBuilder<EduNoteContext>();
            builder.UseSqlServer(Configuration.GetConnectionString("EduNoteDatabase"), b => b.MigrationsAssembly("EduNote.API"));
            Bootstrapper.Bootstrap(container, builder.Options);

            container.Register<IUserService, UserService>(Lifestyle.Scoped);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);


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
            
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.AllowCredentials();
            });

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EduNote API V1");
                c.RoutePrefix = string.Empty;
            });

            // Configure static AutoMapper instance
            Helpers.AutoMapper.Initialize();

            // Verify Simple Injector configuration
            container.Verify();
        }
    }
}
