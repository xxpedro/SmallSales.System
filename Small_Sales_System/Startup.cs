using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Small_Sales_System.Herramientas;
using Small_Sales_System.Servicios;
using Small_Sales_System.Servicios.Interfaces;

namespace Small_Sales_System
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
            services.AddControllers();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Ventas", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                     new string[] {}
                    }
                });
            });

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);


            //JWT

            var appSettingToken = appSettings.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettingToken.Secreto);

            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(d=>{

                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            
            });




            //Inyecciones
            services.AddScoped<IUsuariosServices,UsuariosServices>();
            services.AddScoped<IVentasServices, VentasServices>();
            services.AddScoped<IProductosServices, ProductosServices>();
            services.AddScoped<ITipoProductoServices, TipoProductoServices>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IConceptosServices, ConceptosServices>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => {

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
            });
        }
    }
}
