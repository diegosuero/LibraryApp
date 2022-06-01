using System;
using System.Collections.Generic;
using System.Linq;
using Library.Domain;

namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class SessionOutModel 
    {        
        public Guid token { get; set; }
        public bool isAdmin { get; set; }


        public SessionOutModel() {
         }
  

        public SessionOutModel SetModel(Guid token, bool isAdmin)
        {
            this.token = token;
            this.isAdmin = isAdmin;
            return this;
        }

    }
}