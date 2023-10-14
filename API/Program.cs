
using API.Helper;
using API.Middleware;
using Application.Service;
using Application.Service.Interface;
using Domain.Model;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<SeedDataCSV>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockPriceService, StockPriceService>();
builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7142",
            ValidAudience = "https://localhost:7142",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings").Get<AppSettings>().Secret))
        };
    });
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDataCSV>();
        service.SeedDataContext();
    }
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
