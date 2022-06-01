using System;
using System.Collections.Generic;
using Library.Domain;
using System.Linq;
namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class BookModel : Model<Book, BookModel>
    {
        public int Id {get;set;}
        public string ISBN {get;set;}
        public string Title { get; set; }
        public string Year { get; set; }
        public string Authors { get; set; }
        public int Count { get; set; }
        public bool IsActive { get; set; }

        public BookModel() {
         }

        public BookModel(Book entity)
        {
            SetModel(entity);
        }

         public List<BookModel> ToModel(List<Book> entities)
        {
            return entities.Select(x => ToModel(x)).ToList();
        }

         public BookModel ToModel(Book entity)
        {
            if (entity == null) return null;
            return new BookModel().SetModel(entity);
        }  

        public override Book ToEntity() => new Book()
        {
            Id = this.Id,
            ISBN = this.ISBN,
            Title = this.Title,
            Year = this.Year,
            Count = this.Count,
            IsActive = this.IsActive,
            Authors = this.Authors
        };

        protected override BookModel SetModel(Book entity)
        {
            Id = entity.Id;
            ISBN = entity.ISBN;
            Title = entity.Title;
            Year = entity.Year;
            Count = entity.Count;
            IsActive = entity.IsActive;
            Authors = entity.Authors;
            return this;
        }
    }
}