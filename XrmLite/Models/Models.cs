using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GridMvc.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XrmLite.Models
{

    public class BaseModel
    {
        [Key]        
        [NotMappedColumn]
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

        public BaseModel()
        {
            CreatedBy = "System";
            CreatedDate = DateTime.Now;
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

        [Display(Name = "Contact Type")]
        [UIHint("MultiPickList")]
        public string ContactType { get; set; }

        [Display(Name = "Status")]
        [UIHint("ComboBox")]
        public string Status { get; set; }


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

    }



    public class PickListValue : BaseModel
    {
        public override string ModelDisplayName
        {
            get
            {
                return "Pick List Value";
            }
        }

        public string ModelType { get; set; }        
        public string FieldName  { get; set; }

        [DataType(DataType.MultilineText)]
        public string Values { get; set; }
    }




    public class XrmUserMetadata
    {
        [StringLength(50)]
        [Display(Name = "User Name")]
        public string UserName;


        [StringLength(50)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber;

        [Display(Name = "Phone Number Confirmed")]
        public string PhoneNumberConfirmed;



        [StringLength(50)]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email;

        [Display(Name = "Email Confirmed")]
        public string EmailConfirmed;

        [Display(Name = "Two Factor Enabled")]
        public string TwoFactorEnabled;

        [Display(Name = "Access Failed Count")]
        public string AccessFailedCount;

        [Display(Name = "Lockout Enabled")]
        public string LockoutEnabled;

        [Display(Name = "Lockout End DateUtc")]
        public string LockoutEndDateUtc;

    }

    [MetadataType(typeof(XrmUserMetadata))]
    public class XrmUser : IdentityUser
    {
        public string ModelDisplayName
        {
            get
            {
                return "User";
            }
        }

        [Display(Name = "Created Date")]
        public System.DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [Display(Name = "Last Modified Date")]
        public System.DateTime? LastModifiedDate { get; set; }

        [Display(Name = "Last Modified By")]
        public string LastModifiedBy { get; set; }

        public XrmUser()
        {
            CreatedBy = "System";
            CreatedDate = DateTime.Now;
        }
    }
}