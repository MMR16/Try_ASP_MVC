using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo3_CRUD.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name ="First Name")]
        public string  FName { get; set; }
        [Display(Name ="Last Name")]
        public string LName { get; set; }
        public int Age { get; set; }
    }
}