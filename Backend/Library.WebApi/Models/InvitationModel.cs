using System;
using System.Collections.Generic;
using Library.Domain;
namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class InvitationModel : Model<Invitation, InvitationModel>
    {
        public int Id {get;set;}
        public string Rol {get;set;}
        public string mail { get; set; }
        public Organization Organization { get; set; }

        public InvitationModel() {
         }

        public InvitationModel(Invitation entity)
        {
            SetModel(entity);
        }

        public override Invitation ToEntity() => new Invitation()
        {
            Id = this.Id,
            mail = this.mail,
            Organization = this.Organization,
            Rol = this.Rol
        };

        protected override InvitationModel SetModel(Invitation entity)
        {
            Id = entity.Id;
            Rol = entity.Rol;
            mail = entity.mail;
            Organization = entity.Organization;
            return this;
        }
    }
}