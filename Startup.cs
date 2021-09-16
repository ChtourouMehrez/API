using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using API.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            #region **** Injection Service Repository
            services.AddScoped<IBanqueRepository, BanqueRepository>();
            services.AddScoped<ICategorieRepository, CategorieRepository>();
            services.AddScoped<IChargePatronaleRepository, ChargePatronaleRepository>();
            services.AddScoped<ICongeRepository, CongeRepository>();
            services.AddScoped<IEchelonRepository, EchelonRepository>();
            services.AddScoped<IGrilleRepository, GrilleRepository>();
            services.AddScoped<IJoursFerieRepository, JoursFerieRepository>();
            services.AddScoped<IModeReglementRepository, ModeReglementRepository>();
            services.AddScoped<INatureRepository, NatureRepository>();
            services.AddScoped<IOrganigrammeRepository, OrganigrammeRepository>();
            services.AddScoped<IPersonnelRepository, PersonnelRepository>();
            services.AddScoped<IPrimePersonnelRepository, PrimePersonnelRepository>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IRegimeRepository, RegimeRepository>();
            services.AddScoped<IServiceDepartementRepository, ServiceDepartementRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ITypeCNSSRepository, TypeCNSSRepository>(); 
            services.AddScoped<ITypeContratRepository, TypeContratRepository>();
            services.AddScoped<ITypePaiesRepository, TypePaiesRepository>();
            services.AddScoped<ITypePrimeRepository, TypePrimeRepository>();

            services.AddScoped<IEnfantPersonnelRepository, EnfantPersonnelRepository>();

            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
