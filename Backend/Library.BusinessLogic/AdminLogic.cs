using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class AdminLogic : ILogic<Admin>
    {
        private IRepository<Admin> repository;
        private ILogic<Organization> orgLogic;

        public AdminLogic(IRepository<Admin> aRepository,ILogic<Organization> logicOrg){
            this.repository=aRepository;
            this.orgLogic=logicOrg;
        }

        public Admin Create(Admin anAdmin){
            checkRegister(anAdmin);
            this.repository.Add(anAdmin);
            this.repository.Save();
            return anAdmin;

        }

        public void checkRegister(Admin anAdmin){
             var org = orgLogic.GetAll();
             if(anAdmin.Organization!=null){
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
        }

        public Admin Get(int id){
            return this.repository.Get(id);
        }

        public List<Admin> GetAll(){
            return this.repository.GetAll();
        }

        public Admin Update(int id, Admin anAdmin){
             var admin = this.repository.Get(id);
             ThrowErrorIfItsNull(admin);
             //admin = admin.Update(anAdmin);
             //this.repository.Update(admin);
             this.repository.Save();
             return admin;


        }

        public void Delete(Admin anAdmin){
            ThrowErrorIfItsNull(anAdmin);
            this.repository.Remove(anAdmin);
            this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(Admin anAdmin)
        {
            if (anAdmin == null)
            {
                throw new ArgumentException("El admin no es valido.");
            }
        }



    }
}
