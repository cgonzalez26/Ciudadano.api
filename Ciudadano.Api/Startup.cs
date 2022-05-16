using Ciudadano.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Ciudadano.Api
{
    public class Startup
    {
        private const string CorsPolicy = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext"),
                    o => o.UseNetTopologySuite()));

            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicy,                    
                    builder =>
                    {
                        builder.WithOrigins(
                        Configuration["AllowOrigins:Angular"],
                        Configuration["AllowOrigins:Localhost"],
                        Configuration["AllowOrigins:Mobile"],
                        Configuration["AllowOrigins:ProdSecure"],
                        Configuration["AllowOrigins:ProdInsecure"]
                        ).AllowAnyHeader().AllowAnyMethod();
                    });
            
            });

            services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    //o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    o.UseMemberCasing();
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            //Use this if you are using own authentication
            services.AddJwtAuthentication(Configuration); //cristian

            //services.AddAutoMapper();

            //Use this if you are using IdentityServer authentication
            //services.AddIdentityServerAuthentication(Configuration);
            services.AddPolicies(Configuration);

            services.InjectDependencies();

            services.ConfigureAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Base API .Net Core", Version = "v1" });
                c.CustomSchemaIds(i => i.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Base API .Net Core V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            /*app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());*/
            app.UseCors(CorsPolicy);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
