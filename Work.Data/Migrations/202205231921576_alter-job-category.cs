namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class alterjobcategory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.job_category", "created_at");
            DropColumn("dbo.job_category", "created_by");
            DropColumn("dbo.job_category", "modified_at");
            DropColumn("dbo.job_category", "modified_by");
            DropColumn("dbo.job_category", "status");
        }

        public override void Down()
        {
            AddColumn("dbo.job_category", "status", c => c.Boolean(nullable: false));
            AddColumn("dbo.job_category", "modified_by", c => c.String(maxLength: 200));
            AddColumn("dbo.job_category", "modified_at", c => c.DateTime());
            AddColumn("dbo.job_category", "created_by", c => c.String(maxLength: 200));
            AddColumn("dbo.job_category", "created_at", c => c.DateTime());
        }
    }
}