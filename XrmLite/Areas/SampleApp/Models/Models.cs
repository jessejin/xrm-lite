using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GridMvc.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using XrmLite.Models;

namespace XrmLite.SampleApp.Models
{
   
    public class Contact: BaseModel
    {
        public override string ModelDisplayName
        {
            get
            {
                return "Contact";
            }
        }


        public override string DisplayName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


        [Display(Name = "Contact Type")]
        [UIHint("MultiPickList")]
        public string ContactType { get; set; }

        [Display(Name = "Status")]
        [UIHint("ComboBox")]
        public string Status { get; set; }

        [Required]
        [Display( Name="First Name")]
        public string FirstName{ get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }        

        [Display(Name="Title")]
        public string Title { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime? DateOfBirth { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public virtual ICollection<XrmUser> Users { get; set; }

    }



}