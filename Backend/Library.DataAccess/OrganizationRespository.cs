using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class OrganizationRepository : RepositoryConstructor<Organization>
    {
        public OrganizationRepository(DbContext context)
        {

                this.Context = context;

        }

        public override List<Organization> GetAll(){
                return this.Context.Set<Organization>().Include("Books").ToList();
        }

        public override Organization Get(int id){  
                return this.Context.Set<Organization>().Include("Books").FirstOrDefault(x => x.Id == id);  
        }

        public override Organization GetByToken(Guid id){  
                return this.Context.Set<Organization>().Include("Books").FirstOrDefault(x => x.APIKey == id);  
        }
    }
}