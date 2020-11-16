using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace Demo3_CRUD.Models
{
    public class Student
    {
        [Required(ErrorMessage ="*")]
        [Range(1,30)]
        [Remote("CheckID","Student",AdditionalFields ="FName",ErrorMessage ="Id Is Exist")]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="Please Enter The Name Between 2 & 10 Character")]
        [Required(ErrorMessage ="*")]
        public string  FName { get; set; }

        [Display(Name ="Last Name")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Please Enter The Name Between 2 & 10 Character")]
        [Required(ErrorMessage ="*")]
        public string LName { get; set; }

        [Range(15,60,ErrorMessage ="Age Must Be Between 15 & 60")]
        [Required(ErrorMessage ="*")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}",ErrorMessage ="Please Enter Vaild Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="*"),StringLength(10,MinimumLength =4)]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("PassWord",ErrorMessage ="PassWord Don't Match")]
        public string CPassWord { get; set; }
    }
}