

using API.Core.Business.DBContext;
using API.Uses.Cases.Servicios;
using API.Uses.Cases.UOWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using WebApiConcecionaria.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("WebApiConcecionaria"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
{
    //serializa enums (Role) como string
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});



//------------------------------------------------------
//-------------------SWAGGER----------------------------
//------------------------------------------------------
#region Swagger
builder.Services.AddSwaggerGen(variable => {

    variable.SwaggerDoc("V1", new OpenApiInfo
    {
        Title = "Concecionaria",
        Description = "Gestion de stock y vetas",
        Version = "V1",
        Contact = new OpenApiContact
        {
            Name = "Rizzo",
            Email = "rizzo@gmail.com",
            Url = new Uri("https://www.google.com.ar/%22"),
        },
        License = new OpenApiLicense
        {
            Name = "",
            Url = new Uri("https://www.google.com.ar/%22"),

        }
    });


    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    variable.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {

        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    variable.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[]{}
        }
    });
});
#endregion Swagger
//---------------------------------------------------------------------------------
//---------------------------GENERADOR DE TOKEN------------------------------------
//---------------------------------------------------------------------------------
#region GeneradorToken
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
#endregion GeneradorToken
//---------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(variable2 => {
        variable2.SwaggerEndpoint("/swagger/V1/swagger.json", "Concecionaria");
        variable2.DefaultModelsExpandDepth(-1);
    });
}

app.UseMiddleware<pruevaMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
