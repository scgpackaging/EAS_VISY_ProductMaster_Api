using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductCodeOldAPIs;
using ProductCodeOldAPIs.Models;
using ProductCodeOldAPIs.Repositories;
using ProductCodeOldAPIs.Repositories.Interfaces;
using ProductCodeOldAPIs.Services;
using ProductCodeOldAPIs.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//var stringConnection = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("MyOrigins", policy =>
{
    policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo { Title = "Product Code Old", Version = "v2" });
    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "XApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    c.AddSecurityRequirement(requirement);
});
builder.Services.AddControllersWithViews().
            AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
});

builder.Services.AddDbContext<ProductSpDbContext>(x => x.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
builder.Services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
builder.Services.AddTransient<IProductSpecificationTestService, ProductSpecificationTestService>();
builder.Services.AddTransient<IProductSpecificationService, ProductSpecificationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v2/swagger.json", "Product Code Old API v1"));

app.UseCookiePolicy();

app.UseHttpsRedirection();

app.UseCors("MyOrigins");

app.UseAuthorization();

app.UseMiddleware<ApiKeyMiddleware>();

app.MapControllers();

app.Run();
