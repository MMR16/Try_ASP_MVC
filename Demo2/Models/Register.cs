using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo2.Models
{
    public class Register
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string FName { get; set; }
        public string  LName { get; set; }
        public int DeptId { get; set; }
        public string  DeptName { get; set; }
        public string Desc { get; set; }
    }
}