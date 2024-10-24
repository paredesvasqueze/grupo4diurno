using CapaDatos;
using CapaDomain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Cargar la configuración desde appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Registrar el patrón Singleton para la conexión a la base de datos
builder.Services.AddSingleton(provider =>
    ConexionSingleton.GetInstance(provider.GetRequiredService<IConfiguration>()));

// Registrar el repositorio y la capa de dominio
builder.Services.AddScoped<EmpleadoRepository>();
builder.Services.AddScoped<EmpleadoDomain>();

builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<ProductoDomain>();

builder.Services.AddScoped<DetallesOrdenCompraRepository>();
builder.Services.AddScoped<DetallesOrdenCompraDomain>();

builder.Services.AddScoped<InventarioRepository>();
builder.Services.AddScoped<InventarioDomain>();

builder.Services.AddScoped<ProveedorRepository>();
builder.Services.AddScoped<ProveedorDomain>();

builder.Services.AddScoped<OrdenCompraRepository>();
builder.Services.AddScoped<OrdenCompraDomain>();

builder.Services.AddScoped<CompraRepository>();
builder.Services.AddScoped<CompraDomain>();

builder.Services.AddScoped<CategoriaRepository>();
builder.Services.AddScoped<CategoriaDomain>();

// Registrar los controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Swagger UI
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

