using System;
using Library.Domain;
using Library.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Library.BusinessLogic.Extensions
{
    public static class ILogicBookExtension
    {

        public static List<Book> GetBooksByUser(this ILogic<Book> bookLogic, ILogic<User_Organization> usrOrgLogic, ILogic<Organization> orgLogic, ILogic<User> userLogic, User user){
            var anUser = userLogic.Get(user.Id);
            ThrowErrorUserNoExists(anUser);
            var organizations = usrOrgLogic.GetAll();
            var organizationsUser = organizations.FindAll(x => x.User.Id == anUser.Id).ToList();
            var list = new List<Book>();
            foreach(var org in organizationsUser){
                list = list.Concat(orgLogic.Get(org.Id).Books).ToList();
            }
            return list;

        }
        
        public static void ThrowErrorUserNoExists(User anUser)
        {
            if (anUser == null)
            {
                throw new ArgumentException("El usuario no existe");
            }
        }
    }
}
