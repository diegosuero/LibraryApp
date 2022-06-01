using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class OrganizationLogic : ILogic<Organization>
    {
        private IRepository<Organization> repository;

        public OrganizationLogic(IRepository<Organization> aRepository){
            this.repository=aRepository;
        }

        public Organization Create(Organization anOrganization){
            this.repository.Add(anOrganization);
            this.repository.Save();
            return anOrganization;

        }

        public Organization Get(int id){
            return this.repository.Get(id);
        }

        public List<Organization> GetAll(){
            return this.repository.GetAll();
        }

        public Organization Update(int id, Organization anOrganization){
             var organization = this.repository.Get(id);
             ThrowErrorIfItsNull(organization);
             organization = organization.Update(anOrganization);
             this.repository.Update(organization);
             this.repository.Save();
             return organization;


        }

        public void Delete(Organization anOrganization){
            ThrowErrorIfItsNull(anOrganization);
            this.repository.Remove(anOrganization);
            this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(Organization anOrganization)
        {
            if (anOrganization == null)
            {
                throw new ArgumentException("La Organization no es valida.");
            }
        }



    }
}
