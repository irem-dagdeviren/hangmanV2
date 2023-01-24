using deneme2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deneme2.Context
{
    public class WordDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            var builder = new ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

        }

        public WordDbContext() {
            Console.WriteLine("dbcontext");
        }

        public WordDbContext(DbContextOptions<WordDbContext> options)
        : base(options){
            Console.WriteLine("dbcontext22222");
            Database.EnsureCreated(); 
        }

        public DbSet<Words> Words { get; set; }
        public DbSet<Game> Games { get; set; }  
        public DbSet<Guesses> Guesses { get; set; }
       
    }

}
