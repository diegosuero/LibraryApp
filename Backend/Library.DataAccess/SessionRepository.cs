using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class SessionRepository : RepositoryConstructor<Session>
    {
        public SessionRepository(DbContext context)
        {
            this.Context = context;
        }
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override List<Session> GetAll(){
                return this.Context.Set<Session>().Include("User").ToList();
        }

        public override Session Get(int id){
                return this.Context.Set<Session>().Include("User").FirstOrDefault(x => x.Id == id);
        }
        public override Session GetByToken(Guid id){
                return null;
        }
    }
}