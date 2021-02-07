using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Server.DataAccess;
using Server.DomainModel;
using Microsoft.OpenApi.Models;
using Microsoft.Data.Sqlite;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<SampleDbContext>(options => options.UseSqlite("DataSource=:memory:"));

            var keepAliveConnection = new SqliteConnection("DataSource=:memory:");
            keepAliveConnection.Open();

            services.AddDbContext<SampleDbContext>(options =>
            {
                options.UseSqlite(keepAliveConnection);
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.EnableAnnotations();
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
