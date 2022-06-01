using System;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
namespace Library.DataAccess
{
    public class StudentRepository : RepositoryConstructor<Student>
    {
        public StudentRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<Student> GetAll()
        {
            return this.Context.Set<Student>().ToList();
        }

        public override Student Get(int id)
        {
            return this.Context.Set<Student>().FirstOrDefault(x => x.Id == id);
        }

         public override Student GetByToken(Guid id)
        {
            return null;
        }
    }
}
