using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class BookRepository : RepositoryConstructor<Book>
    {
        public BookRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<Book> GetAll(){
                return this.Context.Set<Book>().ToList();
        }

        public override Book Get(int id){
            return this.Context.Set<Book>().FirstOrDefault(x => x.Id == id);
        }

        public override Book GetByToken(Guid id){
            return null;
        }
    }
}