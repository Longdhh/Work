namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.application_role",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                    Description = c.String(maxLength: 250),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.application_user_role",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.application_role", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.category",
                c => new
                {
                    category_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 200),
                    category_logo = c.String(maxLength: 250),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.category_id);

            CreateTable(
                "dbo.company",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_alias = c.String(maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    description = c.String(maxLength: 500),
                    avatar = c.String(maxLength: 250),
                    banner = c.String(maxLength: 250),
                    fax = c.String(maxLength: 50),
                    followers = c.Long(),
                    is_featured = c.Boolean(),
                    province_id = c.Long(),
                    address = c.String(),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.province", t => t.province_id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.province_id);

            CreateTable(
                "dbo.province",
                c => new
                {
                    province_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.province_id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    description = c.String(maxLength: 500),
                    avatar = c.String(maxLength: 250),
                    birthday = c.DateTime(),
                    gender = c.Boolean(),
                    years_of_experience = c.Long(),
                    last_company = c.String(maxLength: 200),
                    level_id = c.Long(),
                    province_id = c.Long(),
                    address = c.String(maxLength: 200),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.level", t => t.level_id)
                .ForeignKey("dbo.province", t => t.province_id)
                .Index(t => t.level_id)
                .Index(t => t.province_id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.application_user_claim",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.level",
                c => new
                {
                    level_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.level_id);

            CreateTable(
                "dbo.application_user_login",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.error",
                c => new
                {
                    error_id = c.Long(nullable: false, identity: true),
                    error_message = c.String(),
                    stack_trace = c.String(),
                    CreatedDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.error_id);

            CreateTable(
                "dbo.Functions",
                c => new
                {
                    ID = c.String(nullable: false, maxLength: 50, unicode: false),
                    Name = c.String(nullable: false, maxLength: 50),
                    URL = c.String(nullable: false, maxLength: 256),
                    DisplayOrder = c.Int(nullable: false),
                    ParentId = c.String(maxLength: 50, unicode: false),
                    Status = c.Boolean(nullable: false),
                    IconCss = c.String(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Functions", t => t.ParentId)
                .Index(t => t.ParentId);

            CreateTable(
                "dbo.home_slide",
                c => new
                {
                    home_slide_id = c.Long(nullable: false, identity: true),
                    home_slide_name = c.String(maxLength: 250),
                    home_slide_image = c.String(),
                    home_slide_order_by = c.Int(nullable: false),
                    link = c.String(nullable: false, maxLength: 250),
                    isShowing = c.Boolean(nullable: false),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.home_slide_id);

            CreateTable(
                "dbo.job_category",
                c => new
                {
                    job_category_id = c.Long(nullable: false, identity: true),
                    job_id = c.Long(nullable: false),
                    category_id = c.Long(nullable: false),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.job_category_id)
                .ForeignKey("dbo.category", t => t.category_id)
                .ForeignKey("dbo.job", t => t.job_id)
                .Index(t => t.job_id)
                .Index(t => t.category_id);

            CreateTable(
                "dbo.job",
                c => new
                {
                    job_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    salary_range_id = c.Long(),
                    job_requirement = c.String(maxLength: 250),
                    description = c.String(maxLength: 500),
                    Id = c.String(maxLength: 128),
                    job_end_date = c.DateTime(),
                    job_view_count = c.Long(),
                    working_type_id = c.Long(),
                    level_id = c.Long(),
                    province_id = c.Long(),
                    address = c.String(),
                    welfare = c.String(),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.job_id)
                .ForeignKey("dbo.company", t => t.Id)
                .ForeignKey("dbo.level", t => t.level_id)
                .ForeignKey("dbo.province", t => t.province_id)
                .ForeignKey("dbo.salary_range", t => t.salary_range_id)
                .ForeignKey("dbo.working_type", t => t.working_type_id)
                .Index(t => t.salary_range_id)
                .Index(t => t.Id)
                .Index(t => t.working_type_id)
                .Index(t => t.level_id)
                .Index(t => t.province_id);

            CreateTable(
                "dbo.salary_range",
                c => new
                {
                    salary_range_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.salary_range_id);

            CreateTable(
                "dbo.working_type",
                c => new
                {
                    working_type_id = c.Long(nullable: false, identity: true),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.working_type_id);

            CreateTable(
                "dbo.Permissions",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    RoleId = c.String(maxLength: 128),
                    FunctionId = c.String(maxLength: 50, unicode: false),
                    CanCreate = c.Boolean(nullable: false),
                    CanRead = c.Boolean(nullable: false),
                    CanUpdate = c.Boolean(nullable: false),
                    CanDelete = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.application_role", t => t.RoleId)
                .ForeignKey("dbo.Functions", t => t.FunctionId)
                .Index(t => t.RoleId)
                .Index(t => t.FunctionId);

            CreateTable(
                "dbo.security",
                c => new
                {
                    security_id = c.Long(nullable: false, identity: true),
                    title = c.String(maxLength: 200),
                    description = c.String(maxLength: 1000),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.security_id);

            CreateTable(
                "dbo.system_config",
                c => new
                {
                    id = c.Long(nullable: false, identity: true),
                    name = c.String(maxLength: 50),
                    type = c.String(maxLength: 50, unicode: false),
                    value = c.Int(nullable: false),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.id);

            CreateTable(
                "dbo.term_of_service",
                c => new
                {
                    tos_id = c.Long(nullable: false, identity: true),
                    title = c.String(maxLength: 200),
                    description = c.String(maxLength: 1000),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.tos_id);

            CreateTable(
                "dbo.welfare_type",
                c => new
                {
                    welfare_type_id = c.Long(nullable: false, identity: true),
                    welfare_type_logo = c.String(maxLength: 250),
                    seo_alias = c.String(nullable: false, maxLength: 200),
                    name = c.String(nullable: false, maxLength: 200),
                    seo_title = c.String(maxLength: 200),
                    seo_description = c.String(maxLength: 500),
                    created_at = c.DateTime(),
                    created_by = c.String(maxLength: 200),
                    modified_at = c.DateTime(),
                    modified_by = c.String(maxLength: 200),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.welfare_type_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.application_user_role", "RoleId", "dbo.application_role");
            DropForeignKey("dbo.Permissions", "FunctionId", "dbo.Functions");
            DropForeignKey("dbo.Permissions", "RoleId", "dbo.application_role");
            DropForeignKey("dbo.job_category", "job_id", "dbo.job");
            DropForeignKey("dbo.job", "working_type_id", "dbo.working_type");
            DropForeignKey("dbo.job", "salary_range_id", "dbo.salary_range");
            DropForeignKey("dbo.job", "province_id", "dbo.province");
            DropForeignKey("dbo.job", "level_id", "dbo.level");
            DropForeignKey("dbo.job", "Id", "dbo.company");
            DropForeignKey("dbo.job_category", "category_id", "dbo.category");
            DropForeignKey("dbo.Functions", "ParentId", "dbo.Functions");
            DropForeignKey("dbo.application_user_role", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "province_id", "dbo.province");
            DropForeignKey("dbo.application_user_login", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "level_id", "dbo.level");
            DropForeignKey("dbo.company", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.application_user_claim", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.company", "province_id", "dbo.province");
            DropIndex("dbo.Permissions", new[] { "FunctionId" });
            DropIndex("dbo.Permissions", new[] { "RoleId" });
            DropIndex("dbo.job", new[] { "province_id" });
            DropIndex("dbo.job", new[] { "level_id" });
            DropIndex("dbo.job", new[] { "working_type_id" });
            DropIndex("dbo.job", new[] { "Id" });
            DropIndex("dbo.job", new[] { "salary_range_id" });
            DropIndex("dbo.job_category", new[] { "category_id" });
            DropIndex("dbo.job_category", new[] { "job_id" });
            DropIndex("dbo.Functions", new[] { "ParentId" });
            DropIndex("dbo.application_user_login", new[] { "UserId" });
            DropIndex("dbo.application_user_claim", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "province_id" });
            DropIndex("dbo.AspNetUsers", new[] { "level_id" });
            DropIndex("dbo.company", new[] { "province_id" });
            DropIndex("dbo.company", new[] { "Id" });
            DropIndex("dbo.application_user_role", new[] { "RoleId" });
            DropIndex("dbo.application_user_role", new[] { "UserId" });
            DropIndex("dbo.application_role", "RoleNameIndex");
            DropTable("dbo.welfare_type");
            DropTable("dbo.term_of_service");
            DropTable("dbo.system_config");
            DropTable("dbo.security");
            DropTable("dbo.Permissions");
            DropTable("dbo.working_type");
            DropTable("dbo.salary_range");
            DropTable("dbo.job");
            DropTable("dbo.job_category");
            DropTable("dbo.home_slide");
            DropTable("dbo.Functions");
            DropTable("dbo.error");
            DropTable("dbo.application_user_login");
            DropTable("dbo.level");
            DropTable("dbo.application_user_claim");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.province");
            DropTable("dbo.company");
            DropTable("dbo.category");
            DropTable("dbo.application_user_role");
            DropTable("dbo.application_role");
        }
    }
}