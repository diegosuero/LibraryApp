using System;

namespace Library.Domain
{
    public class User
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Mail {get;set;}
        public string Password {get;set;}
        public User(){

        }

        public User Update(User anUser){
            Name = anUser.Name;
            Mail = anUser.Mail;
            Password = anUser.Password;
            return this;
        }

    }


}