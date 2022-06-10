using Harambee.DataAccess.AutoMapper;
using Harambee.DataAccess.DbContext;
using Harambee.DataAccess.Repositories.Contracts;
using Harambee.DataAccess.Repositories.Implementations;
using Harambee.DataAccess.Services.Contracts;
using Harambee.DataAccess.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Harambee
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup API Controllers
            services.AddControllers()
                .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            // Setup CORS
            services.AddCors(opts => opts.AddPolicy("Default", builder =>
            { builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader(); }));

            // Setup Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Harambee", Version = "v1" });
            });

            // Entity Framework Core
            services.AddDbContext<EntityContext>(options =>
            { options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")); });

            // Services
            services.AddScoped<ICartService, CartService>();

            // Repositories
            services.AddScoped<ICartDA, CartDA>();

            // Auto Mapper Configurations
            services.AddAutoMapper(typeof(AutoMapperConfig));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Harambee v1"));
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
