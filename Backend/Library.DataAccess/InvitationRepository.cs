using Library.Domain;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Library.DataAccess
{
    public class InvitationRepository : RepositoryConstructor<Invitation>
    {
        public InvitationRepository(DbContext context)
        {
            this.Context = context;
        }

        public override List<Invitation> GetAll(){
                return this.Context.Set<Invitation>().Include("Organization").ToList();

        }
        [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public override Invitation Get(int id){
                return this.Context.Set<Invitation>().Include("Organization").FirstOrDefault(x => x.Id == id);

        }

        public override Invitation GetByToken(Guid id){
                return null;

        }
    }
}