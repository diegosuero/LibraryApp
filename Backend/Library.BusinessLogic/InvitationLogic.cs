using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Library.BusinessLogic
{
    public class InvitationLogic : ILogic<Invitation>
    {
        private IRepository<Invitation> repository;
        private ILogic<User_Organization> usrLogic;

        public InvitationLogic(IRepository<Invitation> aRepository/*,ILogic<User_Organization> logicUsr*/){
            this.repository=aRepository;
            //this.usrLogic=logicUsr;
        }

        public Invitation Create(Invitation anInvitation){
            this.repository.Add(anInvitation);
            this.repository.Save();
            int id = anInvitation.Id;
            sendEmail(anInvitation.mail,"Invitacion a organizacion "," https://aspangularapp.s3-website-us-east-1.amazonaws.com/invitacion/"+id).Wait();
            return anInvitation;

        }

          static async Task sendEmail(string email, string subjetcem, string contentms)
        {
            var apiKey ="";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("", "LibraryApp");
            var subject = subjetcem;
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>Invitacin a  "+ contentms + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }





        public Invitation Get(int id){
            return this.repository.Get(id);
        }

        public List<Invitation> GetAll(){
            return this.repository.GetAll();
        }

        public Invitation Update(int id, Invitation anAdmin){
             var admin = this.repository.Get(id);
             ThrowErrorIfItsNull(admin);
             //admin = admin.Update(anAdmin);
             //this.repository.Update(admin);
             this.repository.Save();
             return admin;


        }

        public void Delete(Invitation anAdmin){
            ThrowErrorIfItsNull(anAdmin);
            this.repository.Remove(anAdmin);
            this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull( Invitation anAdmin)
        {
            if (anAdmin == null)
            {
                throw new ArgumentException("El admin no es valido.");
            }
        }



    }
}
