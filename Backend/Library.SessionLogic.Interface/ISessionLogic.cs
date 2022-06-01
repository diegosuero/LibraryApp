using System;
using System.Collections.Generic;
using Library.Domain;

namespace Library.SessionLogic.Interface
{
    public interface ISessionLogic<T>
    {
        Guid Login(User aUser);
        void LogOut(Guid token);
        IEnumerable<T> GetAll();
        bool IsAdmin(Guid token);
        User isLogued(Guid token);
    }
}
