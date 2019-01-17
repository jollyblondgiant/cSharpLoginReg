using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace LoginReg.Models {
    public class User {
        
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Please input first Name")]
        [MinLength (3, ErrorMessage = "Name length minimum 3 characters")]
        [Display (Name = "First Name: ")]

        public string FirstName { get; set; }

        [Required (ErrorMessage = "Please input Last Name")]
        [MinLength (3, ErrorMessage = "Nmaes must be at least 3 characters long")]
        [Display (Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Email required")]
        // [Unique(ErrorMessage="Email already in use!")]
        [EmailAddress (ErrorMessage = "No tricks, now")]
        [Display (Name = "Email Address: ")]

        public string Email { get; set; }

        [Required (ErrorMessage = "Password required")]
        [MinLength (8, ErrorMessage = "password length insufficient, build more pylons")]
        [Display (Name = "Password: ")]
        public string Password { get; set; }

        [NotMapped]
        [Compare ("Password")]
        [DataType (DataType.Password)]
        [Display (Name = "Confirm Password: ")]
        public string ConfirmPwd { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // public class UniqueAttribute : ValidationAttribute
        // {
        //     private LoginRegContext dbContext;
        //         public void UniqueVal(LoginRegContext context)
        //         {
        //             dbContext = context;
        //         }
        //     public override bool IsValid(object value)
        //     {
        //         User existingUser = dbContext.Users.FirstOrDefault(u=>u.Email == (string)value);
        //         if(existingUser != null)
        //         {
        //             return false;
        //         }
        //         return true;

        //     }
        // }

    }

}