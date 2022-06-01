using System;
using Library.SessionLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;
using Library.BusinessLogic.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Library.SessionLogic
{
    public class SessionLogic : ISessionLogic<Session>
    {
        private IRepository<Session> sessionRepository;
        private ILogic<User> userLogic;
        private ILogic<Student> studentLogic;
        private ILogic<Admin> adminLogic;

        public SessionLogic(ILogic<User> aUserRepository, IRepository<Session> aSessionRepository,ILogic<Student> aStudentRepository, ILogic<Admin> anAdminLogic){
            this.sessionRepository = aSessionRepository;
            this.userLogic = aUserRepository;
            this.studentLogic = aStudentRepository;
            this.adminLogic =anAdminLogic;
        }

        public IEnumerable<Session> GetAll()
        {
            return this.sessionRepository.GetAll();
        }

        public bool IsAdmin(Guid token)
        {
        
            User user = isLogued(token);
            var admin = adminLogic.Get(user.Id);
            return admin == null ? false : true;
        }

        public User isLogued(Guid token)
        {
            //int exist = this.sessionRepository.GetAll().Where(x=>x.Token==token).ToList().Count;
            User user = this.sessionRepository.GetAll().Where(x=>x.Token==token).FirstOrDefault().User;
            return user;
        }

        public Guid Login(User aUser)
    
        {
            //throw new ArgumentException("El usuario y/o contraseña son incorrectos");
            User user = userLogic.GetAll().Where(x=>x.Mail==aUser.Mail && x.Password==aUser.Password).FirstOrDefault();
            if(user == null)
            {
                throw new ArgumentException("El usuario y/o contraseña son incorrectos");
            }
            Guid token = Guid.NewGuid();
            Session us = new Session(){ Token = token, User = user };
            this.sessionRepository.Add(us);
            this.sessionRepository.Save();
            return token;
        }

        public void LogOut(Guid token)
        {
            this.sessionRepository.Remove(new Session() { Token = token });
        }
    }
}
