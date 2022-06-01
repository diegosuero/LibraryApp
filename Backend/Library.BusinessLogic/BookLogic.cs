using System;
using System.Collections.Generic;
using Library.BusinessLogic.Interface;
using Library.Domain;
using Library.DataAccess.Interface;

namespace Library.BusinessLogic
{
    public class BookLogic : ILogic<Book>
    {
        private IRepository<Book> repository;

        public BookLogic(IRepository<Book> aRepository){
            this.repository=aRepository;
        }

        public Book Create(Book aBook){
            this.repository.Add(aBook);
            this.repository.Save();
            return aBook;

        }

        public Book Get(int id){
            return this.repository.Get(id);
        }

        public List<Book> GetAll(){
            return this.repository.GetAll();
        }

        public Book Update(int id, Book aBook){
             var book = this.repository.Get(id);
             ThrowErrorIfItsNull(book);
             book = book.Update(aBook);
             this.repository.Update(book);
             this.repository.Save();
             return book;


        }

        public void Delete(Book book){
             ThrowErrorIfItsNull(book);
             //chequear el tema de reservas
             book.IsActive=false;
             book = book.Update(book);
             this.repository.Update(book);
             this.repository.Save();
            
        }

        private static void ThrowErrorIfItsNull(Book anOrganization)
        {
            if (anOrganization == null)
            {
                throw new ArgumentException("La Organization no es valida.");
            }
        }



    }
}
