using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XrmLite.Models
{

    public class BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public System.DateTime? LastModifiedDate { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }

        public virtual string ModelDisplayName
        {
            get
            {
                return "BaseObject";
            }
        }

    }
    
    
    public class Contact: BaseModel
    {
        public override string ModelDisplayName
        {
            get
            {
                return "Contact";
            }
        }

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
    }
}