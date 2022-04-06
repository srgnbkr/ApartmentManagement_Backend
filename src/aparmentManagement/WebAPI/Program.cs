using Application.ServiceRegistrations;
using Core.Application.Extensions;
using Core.Application.Pipelines.Caching;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Encryption;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Persistence.Registrations;

var builder = WebApplication.CreateBuilder(args);

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();



builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,          
                        ValidateAudience = true,        
                        ValidateLifetime = true,        
                        ValidIssuer = tokenOptions.Issuer,      
                        ValidAudience = tokenOptions.Audience,  
                        ValidateIssuerSigningKey = true,       
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)   
                    };
                });

builder.Services.AddAuthorization();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<CacheSettings>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLazyResolution();

builder.Services.AddLogging(config =>
{
    config.AddDebug();
    config.AddConsole();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
