using hangmanV1.Services;
using Microsoft.EntityFrameworkCore;
using hangmanV1.DataAccessLayer;
using hangmanV1.Model.RequestModel;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddControllers();

builder.Services.AddDbContext<WordDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;", builder => builder.EnableRetryOnFailure()));
   
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<WordService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IValidator<EnterGuessRequestModel>, GuessValidator>();
builder.Services.AddScoped<GuessValidator>();

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



        //ServiceProvider serviceProvider = new ServiceCollection()
        //                               .AddDbContext<WordDbContext>(options =>
        //                                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;"), ServiceLifetime.Scoped, ServiceLifetime.Scoped)
        //                               .AddScoped<WordService>()
        //                               .BuildServiceProvider();




        //WordService control = serviceProvider.GetService<WordService>();


        }
        }
    
