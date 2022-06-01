using System;
using System.Collections.Generic;
using Library.Domain;
namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class UserModel : Model<User, UserModel>
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Mail { get; set; }
        public string Password { get; set; }

        public UserModel() {
         }

        public UserModel(User entity)
        {
            SetModel(entity);
        }

        public override User ToEntity() => new User()
        {
            Id = this.Id,
            Name = this.Name,
            Mail = this.Mail,
            Password = this.Password
        };

        protected override UserModel SetModel(User entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Mail = entity.Mail;
            Password = entity.Password;
            return this;
        }
    }
}