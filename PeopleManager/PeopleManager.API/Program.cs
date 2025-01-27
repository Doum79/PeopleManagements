using Microsoft.EntityFrameworkCore;
using PeopleManager.Application.Services;
using PeopleManager.Domain.Ports;
using PeopleManager.Infrastructure.DataContext;
using PeopleManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la chaîne de connexion
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IPersonRepository, InMemoryPersonRepository>();
builder.Services.AddScoped<IJobRepository, InMemoryJobRepository>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<JobService>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
