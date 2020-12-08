using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookShopping.Repository
{
    
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        List<TEntity> Get();
        List<Book> Get<Book>() where Book : class;
        List<TEntity> GetWhere(Expression<Func<TEntity, bool>> metot);
        List<Book> GetWhere<Book>(Expression<Func<Book, bool>> metot) where Book : class;
        TEntity GetSingle(Func<TEntity, bool> metot);
        Book GetSingle<Book>(Func<Book, bool> metot) where Book : class;
        TEntity GetById(int id);
        Book GetById<Book>(int id) where Book : class;
        bool Add(TEntity model);
        bool Add<Book>(Book model) where Book : class;
        bool Remove(TEntity model);
        bool Remove<Book>(Book model) where Book : class;
        bool Remove(int id);
        bool Remove<Book>(int id) where Book : class;
        bool Update(TEntity model, int id);
        bool Update<Book>(Book model, int id) where Book : class;
        int Save();
    }

}
