using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class usrOrgLogic : ILogic<User_Organization>
    {
        private IRepository<User_Organization> repository;

        public usrOrgLogic(IRepository<User_Organization> aRepository){
            this.repository=aRepository;
        }

        public User_Organization Create(User_Organization anOrganization){
            this.repository.Add(anOrganization);
            this.repository.Save();
            return anOrganization;

        }

        public User_Organization Get(int id){
            return this.repository.Get(id);
        }

        public List<User_Organization> GetAll(){
            return this.repository.GetAll();
        }

        public User_Organization Update(int id, User_Organization anOrganization){
             var organization = this.repository.Get(id);
             ThrowErrorIfItsNull(organization);
             organization = organization.Update(anOrganization);
             this.repository.Update(organization);
             this.repository.Save();
             return organization;


        }

        public void Delete(User_Organization anOrganization){
            ThrowErrorIfItsNull(anOrganization);
            this.repository.Remove(anOrganization);
            this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(User_Organization anOrganization)
        {
            if (anOrganization == null)
            {
                throw new ArgumentException("La Organization no es valida.");
            }
        }



    }
}
