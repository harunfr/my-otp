using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyOTP.DataAccess;
using MyOTP.Helpers;
using MyOTP.Repositories;
using MyOTP.Services;

namespace MyOTP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://127.0.0.1:5500")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // PostgreSQL DbContext'ini ekleyin
            services.AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("PostgresConnection")));

            // MyEntityRepository'yi ekleyin
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOTPService, OTPService>(); // IOTPService ekleyin

            // Diğer yapılandırmaları ekle
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Diğer yapılandırmaları ekle

            app.UseCors("AllowOrigin");

            // Diğer middleware ve yönlendirmeleri ekle
        }
    }
}
