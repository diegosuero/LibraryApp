using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class UserOrganizarionLogic : ILogic<User_Organization>
    {
        private IRepository<User_Organization> repository;
        private ILogic<Organization> orgLogic;

        public UserOrganizarionLogic(IRepository<User_Organization> aRepository,ILogic<Organization> logicOrg){
            this.repository=aRepository;
            this.orgLogic=logicOrg;
        }

        public User_Organization Create(User_Organization anAdmin){
            //checkRegister(anAdmin);
            this.repository.Add(anAdmin);
            this.repository.Save();
            return anAdmin;

        }
/*
        public void checkRegister(User anAdmin){
             var org = orgLogic.GetAll();
            for (int i = 0; i < org.Count; i++)
            {
                var organizacion = org[i];
                if(organizacion.Name == anAdmin.Organization.Name){
                    throw new ArgumentException("Ya existe la organizacion");
                }
            }
            var usrs = this.GetAll();
            for (int i = 0; i < usrs.Count; i++)
            {
                var usr = usrs[i];
                if(usr.Mail == anAdmin.Mail){
                    throw new ArgumentException("Ya existe el Mail");
                }
            }

        }
*/
        public User_Organization Get(int id){
            return this.repository.Get(id);
        }

        public List<User_Organization> GetAll(){
            return this.repository.GetAll();
        }

        public User_Organization Update(int id, User_Organization anAdmin){
             var admin = this.repository.Get(id);
             ThrowErrorIfItsNull(admin);
             //admin = admin.Update(anAdmin);
             //this.repository.Update(admin);
             this.repository.Save();
             return admin;


        }

        public void Delete(User_Organization anAdmin){
            ThrowErrorIfItsNull(anAdmin);
            this.repository.Remove(anAdmin);
            this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(User_Organization anAdmin)
        {
            if (anAdmin == null)
            {
                throw new ArgumentException("El admin no es valido.");
            }
        }



    }
}
