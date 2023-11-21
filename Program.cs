using Microsoft.EntityFrameworkCore;
using TeachersBingoApi.Data;
using TeachersBingoApi.Repositories.Implementations;
using TeachersBingoApi.Repositories.Interfaces;
using TeachersBingoApi.Services.Implementations;
using TeachersBingoApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corsConfig",
                      policy =>
                      {
                          policy
                              .WithOrigins("http://localhost:5173")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultSQLConnection"), new MySqlServerVersion(new Version(10, 4, 27)));
});
builder.Services.AddScoped<IBingoRepository, BingoRepository>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddScoped<IBingoGameRepository, BingoGameRepository>();

builder.Services.AddScoped<IBingoService, BingoService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IBingoGameService, BingoGameService>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsConfig");

app.UseAuthorization();

app.MapControllers();

app.Run();
