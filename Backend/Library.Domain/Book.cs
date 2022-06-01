using System;

namespace Library.Domain
{
    public class Book
    {
        public int Id {get;set;}
        public string ISBN {get;set;}
        public string Title {get;set;}
        public string Year {get;set;}
        public string Authors {get;set;}
        public int Count {get;set;}
        public bool IsActive {get;set;}
        public Book(){
            this.IsActive= true;

        }

        public Book Update(Book aBook){
            ISBN = aBook.ISBN;
            Title = aBook.Title;
            Year = aBook.Year;
            Authors = aBook.Authors;
            Count = aBook.Count;
            IsActive = aBook.IsActive;
            return this;
        }

    }


}