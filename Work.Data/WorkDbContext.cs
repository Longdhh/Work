using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Work.Model.Models;

namespace Work.Data
{
    public class WorkDbContext : IdentityDbContext<ApplicationUser>
    {
        public WorkDbContext() : base("WorkConnection9")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<ApplicationRole> application_roles { set; get; }
        public DbSet<Category> categories { get; set; }
        public DbSet<HomeSlide> home_slides { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<JobCategory> job_categories { get; set; }
        public DbSet<JobUser> job_users { get; set; }
        public DbSet<Welfare> welfares { get; set; }
        public DbSet<Level> levels { get; set; }
        public DbSet<Province> provinces { get; set; }
        public DbSet<Security> securities { get; set; }
        public DbSet<SystemConfig> system_configs { get; set; }
        public DbSet<TermsOfService> terms_of_services { get; set; }
        public DbSet<Function> functions { set; get; }
        public DbSet<Permission> permissions { set; get; }
        public DbSet<WelfareType> welfare_types { get; set; }
        public DbSet<WorkingType> working_types { get; set; }
        public DbSet<Error> errors { get; set; }
        public DbSet<SalaryRange> salary_ranges { get; set; }
        public DbSet<IdentityUserRole> user_roles { set; get; }
        public DbSet<Announcement> announcements { set; get; }
        public DbSet<AnnouncementUser> announcement_users { set; get; }

        public static WorkDbContext Create()
        {
            return new WorkDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().HasOptional(c => c.company).WithRequired(d => d.user);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id).ToTable("application_role");
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("application_user_role");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("application_user_login");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("application_user_claim");
        }
    }
}