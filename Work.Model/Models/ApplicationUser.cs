using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Work.Model.Models
{
    [Table("application_user")]
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string name { get; set; }

        [MaxLength(200)]
        public string seo_title { get; set; }

        [MaxLength(500)]
        public string seo_description { get; set; }

        [MaxLength(500)]
        public string description { get; set; }

        [MaxLength(250)]
        public string avatar { get; set; }

        public DateTime? birthday { get; set; }
        public bool? gender { get; set; }
        public long? years_of_experience { get; set; }

        [MaxLength(200)]
        public string last_company { get; set; }

        public long? level_id { set; get; }

        [ForeignKey("level_id")]
        public virtual Level level { get; set; }

        public long? province_id { get; set; }

        [MaxLength(200)]
        public string address { get; set; }

        [ForeignKey("province_id")]
        public virtual Province province { get; set; }

        public virtual IEnumerable<JobUser> job_users { get; set; }
        public DateTime? created_at { get; set; }

        [MaxLength(200)]
        public string created_by { get; set; }

        public DateTime? modified_at { get; set; }

        [MaxLength(200)]
        public string modified_by { get; set; }

        public virtual Company company { get; set; }

        [Required]
        public bool status { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}