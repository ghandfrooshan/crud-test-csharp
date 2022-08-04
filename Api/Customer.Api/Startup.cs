
using Framework.AssemblyHelper;
using Framework.Core.Persistence;
using Framework.DependencyInjection;
using Framework.Facade;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Customer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer.Api v1"));
        //    }

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //}


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                
                app.UseExceptionHandler("/Home/Error");
                //changed place of migration
                var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
                var context = serviceScope.ServiceProvider.GetService<IDbContext>();
                context.Migrate();
            }

            //app.ConfigureErrorHandlingMiddleware();
            app.UseCors("CrossDomainPolicy");


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Customer V1");
                c.DocExpansion(DocExpansion.None);
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{Controller=swagger}/{action=Index.html}");
            });

            app.UseMvc();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer.Api", Version = "v1" });

        //    });
        //}
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyHelper = new AssemblyHelper(nameof(CustomerContext));
            services.AddHttpContextAccessor();
          
            Registrar(services, assemblyHelper);

            var mvcBuilder = services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                //option.Filters.Add(new ActiveUserFilter());
            })
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            AddControllers(assemblyHelper, mvcBuilder);

            mvcBuilder.AddControllersAsServices();

            services.AddCors(o => o.AddPolicy("CrossDomainPolicy",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "v1" });

                
            });

           

           
        }



        private void Registrar(IServiceCollection services, AssemblyHelper assemblyHelper)
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", true, true);
               

            var connectionString = builder.Build().GetConnectionString("DefaultConnection");
            var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
            foreach (IRegistrar registrar in registrars)
                registrar.Register(services, connectionString);

            services.AddDbContext<CustomerContext.ReadModel.Context.Models.CustomerContext>(op =>
            {
                op.UseSqlServer(connectionString, z => z.CommandTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds));


            }, ServiceLifetime.Transient);


        }



        private static void AddControllers(AssemblyHelper assemblyHelper, IMvcBuilder mvcBuilder)
        {
            var controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeCommandBase)).Distinct();

            foreach (var apiControllerAssembly in controllerAssemblies)
                mvcBuilder.AddApplicationPart(apiControllerAssembly);

            controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeQueryBase)).Distinct();
            foreach (var apiControllerAssembly in controllerAssemblies)
                mvcBuilder.AddApplicationPart(apiControllerAssembly);
        }
    }
}
