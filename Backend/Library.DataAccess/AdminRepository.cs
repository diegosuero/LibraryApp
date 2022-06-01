using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class AdminRepository : RepositoryConstructor<Admin>
    {
        public AdminRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<Admin> GetAll(){
                return this.Context.Set<Admin>().Include("Organization").ToList();

        }
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override Admin Get(int id){
                return this.Context.Set<Admin>().Include("Organization").FirstOrDefault(x => x.Id == id);

        }

        public override Admin GetByToken(Guid id){
                return null;

        }
    }
}