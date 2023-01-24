
using deneme2.Context;
using deneme2.Model;
using deneme2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddScoped<wordService>();
builder.Services.AddDbContext<WordDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;", builder => builder.EnableRetryOnFailure()));
   
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

partial class Program
{

    static void Main(string[] args)
    {



        ServiceProvider serviceProvider = new ServiceCollection()
                                       .AddDbContext<WordDbContext>(options =>
                                        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;"), ServiceLifetime.Scoped, ServiceLifetime.Scoped)
                                       .AddTransient<wordService>()
                                       .BuildServiceProvider();




        wordService control = serviceProvider.GetService<wordService>();

       
            }
        }
    
