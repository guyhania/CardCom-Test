using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CardCom.Models
{
    public class Person
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "Enter ID")]
        [StringLength(9,MinimumLength =9,ErrorMessage ="Please enter a valid ID")]
        public string PersonId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Enter first name")]
        [StringLength(50, ErrorMessage = "Please enter a valid name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter last name")]
        [StringLength(50, ErrorMessage = "Please enter a valid last name")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(65, ErrorMessage = "Please enter a valid Email address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress",ErrorMessage ="The email must match")]
        public string ConfirmEmailAddress { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "Enter date of birth")]
        [DataType(DataType.Date )]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber )]
        [StringLength(10,ErrorMessage ="Enter valid phone number")]
        public string PhoneNumber { get; set; }
    }
  }