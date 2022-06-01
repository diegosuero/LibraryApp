using System;
using System.Collections.Generic;

namespace Library.Domain
{
    public class Organization
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public Guid APIKey {get;set;}
        public List<Book> Books {get;set;}
        public List<Reservation> reservations {get;set;}

        public Organization(){
            this.APIKey = Guid.NewGuid();

        }

        public Organization Update(Organization anOrganization){
            Name = anOrganization.Name;
            APIKey = anOrganization.APIKey;
            return this;
        }

        public Organization updateApiKey(){
            this.APIKey = Guid.NewGuid();
            return this;
        }

        public void addBook(Book book){
            this.Books.Add(book);
        }

    }


}