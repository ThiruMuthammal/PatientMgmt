using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PatientManagement.Services;
using System.Text;

namespace PatientManagement
{
    public class Startup
    {
        public readonly IAuthService authServiceauthService;
        public WebApplication InitializeApp(string[] args)
        {
            var configure = new Startup();
            var builder = WebApplication.CreateBuilder(args);
            configure.ConfigureService(builder);
            var app = builder.Build();
            configure.Configure(app);
            return app;
        }

        public void ConfigureService(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Patientmanagement API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "jwtBearer";
                options.DefaultChallengeScheme = "jwtBearer";

            }).AddJwtBearer("jwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:Key:This is a sample secret key")),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = "https://localhost:7266",
                    ValidAudience = "https://localhost:7266"
                };
            });
            builder.Services.AddTransient<IAuthService, AuthService>();
            builder.Services.AddTransient<IPatientServices, PatientServices>();
            builder.Services.AddScoped<IJsonSerialize, JsonSerialize>();

        }

        public void Configure(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
