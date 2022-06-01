using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
namespace Library.DataAccess
{
    public class ReservationRepository : RepositoryConstructor<Reservation>
    {
        public ReservationRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<Reservation> GetAll(){
            return this.Context.Set<Reservation>().Include("book").ToList();
        }

        public override Reservation Get(int id){
            return this.Context.Set<Reservation>().Include("book").FirstOrDefault(x => x.Id == id);
        }

        public override Reservation GetByToken(Guid id){
            return null;
        }

    }
}