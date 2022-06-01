using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class User_OrganizationRepository : RepositoryConstructor<User_Organization>
    {
        public User_OrganizationRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<User_Organization> GetAll(){
            return this.Context.Set<User_Organization>().Include("User").Include("Organization").Include("User").Include("Reservation").ToList();
        }

        public override User_Organization Get(int id){
            return this.Context.Set<User_Organization>().Include("User").Include("Organization").Include("User").Include("Reservation").FirstOrDefault(x => x.Id == id);
        }
        public override User_Organization GetByToken(Guid id)
        {
            return null;
        }
    }
}