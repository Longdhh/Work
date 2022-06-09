namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class add_job_user : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.job_user",
                c => new
                {
                    job_user_id = c.Long(nullable: false, identity: true),
                    job_id = c.Long(nullable: false),
                    Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.job_user_id)
                .ForeignKey("dbo.job", t => t.job_id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.job_id)
                .Index(t => t.Id);

            AddColumn("dbo.job", "job_registed_user", c => c.Long(nullable: false));
            DropColumn("dbo.announcement", "email");
            DropColumn("dbo.announcement", "phone_number");
            DropColumn("dbo.announcement", "resume");
        }

        public override void Down()
        {
            AddColumn("dbo.announcement", "resume", c => c.String());
            AddColumn("dbo.announcement", "phone_number", c => c.String());
            AddColumn("dbo.announcement", "email", c => c.String());
            DropForeignKey("dbo.job_user", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.job_user", "job_id", "dbo.job");
            DropIndex("dbo.job_user", new[] { "Id" });
            DropIndex("dbo.job_user", new[] { "job_id" });
            DropColumn("dbo.job", "job_registed_user");
            DropTable("dbo.job_user");
        }
    }
}