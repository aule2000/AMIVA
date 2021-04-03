using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SmartSaver.Domain;
using SmartSaver.Domain.Repositories;
using SmartSaver.Domain.Repositories.Interfaces;
using System;
using System.IO;
using System.Reflection;

namespace SmartSaver.Server
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

<<<<<<< HEAD
            services.AddDbContext<SmartSaverContext>(options => options.UseSqlServer(@"Server=LAPTOP-GDGGLB6I\AUKSESQL;Database=AMIVA;Integrated Security=True"));
            
=======
            services.AddDbContext<SmartSaverContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AzureDBConnectionString"))
            );

>>>>>>> fef368b34852c0f4d7133542814a7b5d48df071b
            services.AddTransient<ITransactionsRepository, TransactionsRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ISavingGoalsRepository, SavingsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(opts => opts.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));

            // configure basic authentication 
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("client", new OpenApiInfo
                {
                    Title = "Client API",
                    Version = "v1",
                    Description = "AMIVA Smart Saver client API"
                });

                c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
                {
                    Name = "Basic",
                    Description = "Please enter your username and password",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.OperationFilter<AddAuthHeaderOperationFilter>();
                c.CustomOperationIds(d => (d.ActionDescriptor as ControllerActionDescriptor)?.ActionName);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
                c.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/client/swagger.json", "Client API");
            });



            //}

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
