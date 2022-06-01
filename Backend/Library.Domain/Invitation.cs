using System;

namespace Library.Domain
{
    public class Invitation
    {
        public int Id {get;set;}
        public Organization Organization {get;set;}
        public string Rol{get;set;}
        public string mail{get;set;}
        
        public Invitation(){

        }
    }

    


}