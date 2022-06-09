namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class alterdatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.job_user", "name", c => c.String());
            AddColumn("dbo.job_user", "email", c => c.String());
            AddColumn("dbo.job_user", "phone_number", c => c.String());
            AddColumn("dbo.job_user", "resume", c => c.String());
            AddColumn("dbo.job_user", "created_at", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.job_user", "created_at");
            DropColumn("dbo.job_user", "resume");
            DropColumn("dbo.job_user", "phone_number");
            DropColumn("dbo.job_user", "email");
            DropColumn("dbo.job_user", "name");
        }
    }
}