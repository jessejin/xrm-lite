using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GridMvc.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using XrmLite.SampleApp.Models;

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
        public virtual string DisplayName
        {
            get
            {
                return "Display Name not implemented";
            }
        }


        public BaseModel()
        {
            CreatedBy = "System";
            CreatedDate = DateTime.Now;
        }

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

        [Display(Name = "Contact")]
        [UIHint("Lookup")]
        public int? ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact UserContact { get; set; }

        public XrmUser()
        {
            CreatedBy = "System";
            CreatedDate = DateTime.Now;
        }
    }
}