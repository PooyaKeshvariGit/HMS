using AutoMapper;
using HiringManagementSystem.Application.Profiles;
using HiringManagementSystem.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace HiringManagementSystem.WebAPI
{
    public class Startup
    {
        #region [-Ctor-]

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region [-Props-]

        public IConfiguration Configuration { get; }

        #endregion

        #region [-ConfigureServices(IServiceCollection services)-]

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region [-AddMvcCore().AddApiExplorer()-]

            services.AddMvcCore().AddApiExplorer();

            #endregion

            #region [- AddDbContext() -]

            services.AddDbContextPool<HiringManagementSystemDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("Default"));

            });

            #endregion

            #region [- AddAutoMapper() -]

            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            }).CreateMapper();

            services.AddSingleton(mappingConfig);

            #endregion

            #region [-AddControllers()-]

            services.AddControllers();

            #endregion

            #region [-DefaultSwaggerConfig-]Commented

            //services.AddSwaggerGen(c =>
            //    {
            //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "HiringManagementSystem.WebAPI", Version = "v1" });
            //    });

            #endregion 

            #region [- AddSwaggerDocument() -]

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ToDo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });

            #endregion

            #region [-TanvirArjel-Registrar-]

            services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();

            services.AddServicesOfAllTypes();

            #endregion
        }

        #endregion

        #region [-Configure(IApplicationBuilder app, IWebHostEnvironment env)-]

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseOpenApi();
                app.UseSwaggerUi3();
                app.UseDeveloperExceptionPage();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HiringManagementSystem.WebAPI v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion
    }
}
