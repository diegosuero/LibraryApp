using System;

namespace Library.Domain
{
    public class Reservation
    {
        public int Id {get;set;}
        //public User_Organization Student {get;set;}
        public DateTime InitDate {get;set;}
        public DateTime FinalDate {get;set;}
        public Book book {get;set;}
        public Reservation(){

        }

        public Reservation Update(Reservation aReservation){
            //Student = aReservation.Student;
            InitDate = aReservation.InitDate;
            FinalDate = aReservation.FinalDate;
            return this;
        }

    }


}