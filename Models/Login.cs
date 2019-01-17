using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LoginReg.Models
{
    public class Login
    {
        // [Exists(ErrorMessage="Can't find that email. maybe <a href ='/'>register?</a>")]
        // [Exists(ErrorMessage="Can't find that email. maybe register?")]
        [Required(ErrorMessage="What's your Email?")]
        [Display(Name="Email: ")]
        public string Email {get;set;}

        [Required(ErrorMessage="What's the secret password?")]
        [Display(Name="Password")]
        public string Password {get;set;}


        // public class ExistsAttribute : ValidationAttribute
        // {
        //     private LoginRegContext dbContext;
        //         public void ExistsVal(LoginRegContext context)
        //         {
        //             dbContext = context;
        //         }
        //     public override bool IsValid(object value)
        //     {
        //         User existingUser = dbContext.Users.FirstOrDefault(u=>u.Email == (string)value);
        //         if(existingUser == null)
        //         {
        //             return false;
        //         }
        //         return true;

        //     }
        // }
        

    }
}