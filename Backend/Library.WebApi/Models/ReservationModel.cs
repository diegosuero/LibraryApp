using System;
using System.Collections.Generic;
using Library.Domain;
using System.Linq;
namespace Library.WebApi.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class ReservationModel : Model<Reservation, ReservationModel>
    {
        public int Id ;
        //public User_Organization Student ;
        public DateTime initDate;
        public DateTime finalDate ;
        public Book book ;

        public ReservationModel() {
         }

        public ReservationModel(Reservation entity)
        {
            SetModel(entity);
        }

        public override Reservation ToEntity() => new Reservation()
        {
            Id = this.Id,
            //Student = this.Student,
            InitDate = this.initDate,
            FinalDate = this.finalDate,
            book = this.book,
        };

        protected override ReservationModel SetModel(Reservation entity)
        {
            Id = entity.Id;
            //Student = entity.Student;
            initDate = entity.InitDate;
            finalDate = entity.FinalDate;
            book = entity.book;
            return this;
        }
    }
}