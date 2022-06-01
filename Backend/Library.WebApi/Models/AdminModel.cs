using System;
using System.Collections.Generic;
using Library.Domain;
namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class AdminModel : Model<Admin, AdminModel>
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public Organization Organization { get; set; }

        public AdminModel() {
         }

        public AdminModel(Admin entity)
        {
            SetModel(entity);
        }

        public override Admin ToEntity() => new Admin()
        {
            Id = this.Id,
            Name = this.Name,
            Mail = this.Email,
            Organization = this.Organization,
            Password = this.Password
        };

        protected override AdminModel SetModel(Admin entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Email = entity.Mail;
            Organization = entity.Organization;
            Password = entity.Password;
            return this;
        }
    }
}