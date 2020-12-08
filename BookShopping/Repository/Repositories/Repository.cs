using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookShopping.Repository
{
    public class Repository<Type> : ControllerBase, IRepository<Type> where Type : class
    {
        protected BookContext _bookContext;
        public Repository(BookContext context)
        {
            IServiceCollection services = new ServiceCollection();
            //  services.AddDbContextService();
            ServiceProvider provider = services.BuildServiceProvider();

            _bookContext = provider.GetService<BookContext>();
        }
        [NonAction]
        public DbSet<Type> Table()
        {
            return Table<Type>();
        }
        [NonAction]
        public DbSet<Book> Table<Book>() where Book : class
        {
            return _bookContext.Set<Book>();
        }
        [NonAction]
        public bool Add(Type model)
        {
            return Add<Type>(model);
        }
        [NonAction]
        public bool Add<Book>(Book model) where Book : class
        {
            Table<Book>().Add(model);
            Save();
            return true;
        }
        [NonAction]
        public List<Type> Get()
        {
            return Get<Type>();
        }
        [NonAction]
        public List<Book> Get<Book>() where Book : class
        {
            return Table<Book>().ToList();
        }
        [NonAction]
        public Type GetById(int id)
        {
            return GetById<Type>(id);
        }
        [NonAction]
        public Book GetById<Book>(int id) where Book : class
        {
            return GetSingle<Book>(t => typeof(Book).GetProperty("Id").GetValue(t).ToString() == id.ToString());
        }
        [NonAction]
        public bool Remove(Type model)
        {
            return Remove<Type>(model);
        }
        [NonAction]
        public bool Remove<Book>(Book model) where Book : class
        {
            Table<Book>().Remove(model);
            return true;
        }
        [NonAction]
        public bool Remove(int id)
        {
            return Remove<Type>(id);
        }
        [NonAction]
        public bool Remove<Book>(int id) where Book : class
        {
            Book delete = GetSingle<Book>(x => (int)typeof(Book).GetProperty("Id").GetValue(x) == id);
            Remove<Book>(delete);
            Save();
            return true;
        }
        [NonAction]
        public int Save()
        {
            return _bookContext.SaveChanges();
        }
        [NonAction]
        public bool Update(Type model, int id)
        {
            return Update<Type>(model, id);
        }
        [NonAction]
        public bool Update<Book>(Book model, int id) where Book : class
        {
            Book update = GetById<Book>(id);
            var tumPropertyler = typeof(Book).GetProperties();
            foreach (var property in tumPropertyler)
                if (property.Name != "Id")
                    property.SetValue(update, property.GetValue(model));
            Save();
            return true;
        }
        [NonAction]
        public List<Type> GetWhere(Expression<Func<Type, bool>> metot)
        {
            return GetWhere<Type>(metot);
        }
        [NonAction]
        public List<Book> GetWhere<Book>(Expression<Func<Book, bool>> metot) where Book : class
        {
            return Table<Book>().Where(metot).ToList();
        }
        [NonAction]
        public Type GetSingle(Func<Type, bool> metot)
        {
            return GetSingle<Type>(metot);
        }
        [NonAction]
        public Book GetSingle<Book>(Func<Book, bool> metot) where Book : class
        {
            return Table<Book>().FirstOrDefault(metot);
        }

        List<Type> IRepository<Type>.Get()
        {
            throw new NotImplementedException();
        }

        List<Book> IRepository<Type>.Get<Book>()
        {
            throw new NotImplementedException();
        }

        List<Type> IRepository<Type>.GetWhere(Expression<Func<Type, bool>> metot)
        {
            throw new NotImplementedException();
        }

        List<Book> IRepository<Type>.GetWhere<Book>(Expression<Func<Book, bool>> metot)
        {
            throw new NotImplementedException();
        }

        Type IRepository<Type>.GetSingle(Func<Type, bool> metot)
        {
            throw new NotImplementedException();
        }

        Book IRepository<Type>.GetSingle<Book>(Func<Book, bool> metot)
        {
            throw new NotImplementedException();
        }

        Type IRepository<Type>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Book IRepository<Type>.GetById<Book>(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Add(Type model)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Add<Book>(Book model)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Remove(Type model)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Remove<Book>(Book model)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Remove(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Remove<Book>(int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Update(Type model, int id)
        {
            throw new NotImplementedException();
        }

        bool IRepository<Type>.Update<Book>(Book model, int id)
        {
            throw new NotImplementedException();
        }

        int IRepository<Type>.Save()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
