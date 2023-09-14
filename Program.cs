using Factory_Server.Contexts;
using Factory_Server.Services;
using Factory_Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserSqlContext>((opt) => opt.UseSqlServer(builder.Configuration.GetConnectionString("sql")));
builder.Services.AddScoped<IUserService, SqlUserService>();
builder.Services.AddScoped<MongoDbUserService>();
builder.Services.AddScoped<OracleUserService>();

var proveedor = builder.Services.BuildServiceProvider();
var configution = proveedor.GetRequiredService<IConfiguration>(); ;
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
});




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
