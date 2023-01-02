using CallCenter.Entities.Entities;
using CallCenter.Services;
using CallCenter.Utilities.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;


namespace CallCenter
{
    public class Startup
    {
        readonly string CorsConfiguration = "_corsConfiguration";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureSevices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));            
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Call Center API",
                Description = "Api desarrollada en .NET 6",
                Contact = new OpenApiContact
                {
                    Name = "John Batista",
                    Email = "johnk_batista@yahoo.com"
                }

            }));
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsConfiguration,
                                       builder =>
                                       {
                                           builder.WithOrigins("http://localhost:4200");
                                       });
            });
            services.AddScoped<ClientesService>();
            services.AddScoped(typeof(IRepository<>),typeof(CallRepository<>));
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(CorsConfiguration);
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}

