using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NutcacheTest.Common.Config;
using NutcacheTest.Repository;
using NutcacheTest.Repository.Context;
using NutcacheTest.Repository.Interfaces;
using NutcacheTest.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

ConfigureServices(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p =>
    p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("corsapp");
app.Run();

void ConfigureServices(IServiceCollection services) {
    services.AddDbContext<DataContext>(x => x.UseMySQL(new Config().GetConnectionString()));

    services.AddTransient<IConfig, Config>();
    services.AddScoped<IDataContext, DataContext>();
    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUsersService, UsersService>();

}