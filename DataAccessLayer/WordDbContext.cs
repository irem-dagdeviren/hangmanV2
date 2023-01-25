
using hangmanV1.Model;
using hangmanV1.Model.Entity;
using Microsoft.EntityFrameworkCore;


namespace hangmanV1.DataAccessLayer
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

        
        public WordDbContext(DbContextOptions<WordDbContext> options)
        : base(options){
            Console.WriteLine("dbcontext");
            Database.EnsureCreated(); 
        }

        public WordDbContext() { }
        public DbSet<Words> Words { get; set; }
        public DbSet<Game> Games { get; set; }  
        public DbSet<Guesses> Guesses { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {

            modelBuilder.Entity<Guesses>().Property(p => p.letter).HasMaxLength(1);
            //primary keys
            modelBuilder.Entity<Game>().HasKey(s => s.ID);
            modelBuilder.Entity<Words>().HasKey(s => s.ID);
            modelBuilder.Entity<Users>().HasKey(s => s.ID);



        }

        }

}
