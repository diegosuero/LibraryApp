using System;

namespace Library.Domain
{
    public class Admin :User
    {
        public Organization Organization {get;set;}
        
        public Admin(){

        }
    }

    


}