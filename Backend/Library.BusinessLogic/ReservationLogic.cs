using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class ReservationLogic : ILogic<Reservation>
    {
        private IRepository<Reservation> repository;

        public ReservationLogic(IRepository<Reservation> aRepository){
            this.repository=aRepository;
        }

        public Reservation Create(Reservation aBook){
            this.repository.Add(aBook);
            this.repository.Save();
            return aBook;

        }

        public Reservation Get(int id){
            return this.repository.Get(id);
        }

        public List<Reservation> GetAll(){
            return this.repository.GetAll();
        }

        public Reservation Update(int id, Reservation aBook){
             var book = this.repository.Get(id);
             ThrowErrorIfItsNull(book);
             book = book.Update(aBook);
             this.repository.Update(book);
             this.repository.Save();
             return book;


        }

        public void Delete(Reservation book){
             ThrowErrorIfItsNull(book);
             this.repository.Remove(book);
             this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(Reservation anOrganization)
        {
            if (anOrganization == null)
            {
                throw new ArgumentException("La Organization no es valida.");
            }
        }



    }
}
