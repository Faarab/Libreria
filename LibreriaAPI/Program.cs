using LibreriaAPI.Data;
using LibreriaAPI.Mappings;
using LibreriaAPI.Repositories;
using LibreriaAPI.Repositories.MarchioRep;
using LibreriaAPI.Repositories.StatoRep;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibreriaDbContext>(options => 
options.UseMySQL(builder.Configuration.GetConnectionString("LibreriaConnectionString")));

builder.Services.AddScoped<IMarchioRepository, SQLMarchioRepository>();
builder.Services.AddScoped<IStatoRepository, SQLStatoRepository>();
builder.Services.AddScoped<ITipologiaRepository, SQLTipologiaRepository>();
builder.Services.AddScoped<ICategoriaRepository, SQLCategoriaRepository>();
builder.Services.AddScoped<IDocumentoRepository, SQLDocumentoRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddCors(options =>
{
    var frontendURL = configuration.GetValue<string>("frontend_url");
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendURL).AllowAnyMethod().AllowAnyHeader();
    });
});



//builder.Services.AddTransient<MySqlConnection>(_ =>
//    new MySqlConnection(builder.Configuration.GetConnectionString("LibreriaConnectionString")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
