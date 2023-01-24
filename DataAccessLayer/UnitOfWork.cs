using deneme2.Model;
using hangmanV1.Context;
using hangmanV1.DataAccessLayer;
using hangmanV1.Model;
using hangmanV1.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace hangmanV1.DataAccessLayer
{
     public class UnitOfWork : IDisposable
    {
        private readonly WordDbContext context = new();
        private GenericRepository<Words>? wordRepository;
        private GenericRepository<Game>? gameRepository;
        private GenericRepository<Users>? userRepository;

        public GenericRepository<Game> GameRepository
        {
            get
            {
                gameRepository= new GenericRepository<Game>(context);
               return gameRepository;
            }
        }

        public GenericRepository<Words> WordRepository
        {
            get
            {
                wordRepository = new GenericRepository<Words>(context);
                return wordRepository;
            }
        }
        public GenericRepository<Users> UserRepository
        {
            get
            {
                userRepository = new GenericRepository<Users>(context);
                return userRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}