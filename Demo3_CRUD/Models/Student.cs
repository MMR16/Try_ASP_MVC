using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo3_CRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string  FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
    }
}