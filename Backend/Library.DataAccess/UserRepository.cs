using System;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataAccess
{
    public class UserRepository : RepositoryConstructor<User>
    {
        public UserRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<User> GetAll()
        {
            return this.Context.Set<User>().ToList();
        }

        public override User Get(int id)
        {
            return this.Context.Set<User>().Find(id);
        }

        public override User GetByToken(Guid id)
        {
            return null;
        }
    }
}