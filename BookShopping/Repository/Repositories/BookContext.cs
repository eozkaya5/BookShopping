using Microsoft.EntityFrameworkCore;
using System;

namespace BookShopping.Repository
{
    public class BookContext
    {
        internal DbSet<Book> Set<Book>() where Book : class
        {
            throw new NotImplementedException();
        }

        internal int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}