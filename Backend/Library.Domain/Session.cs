using System;
using System.Collections.Generic;

namespace Library.Domain
{
    public class Session
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public User User { get; set; }
        public Session() { }
    }

}   