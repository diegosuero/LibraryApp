using System;
using System.Collections.Generic;
namespace Library.Domain
{
    public class User_Organization
    {
        public int Id {get;set;}
        public User User {get;set;}
        public Organization Organization {get;set;}
        public List<Reservation> Reservation {get;set;}
        public User_Organization(){

        }

        public User_Organization Update(User_Organization anOrganization){
            User = anOrganization.User;
            Organization = anOrganization.Organization;
            return this;
        }

    }


}