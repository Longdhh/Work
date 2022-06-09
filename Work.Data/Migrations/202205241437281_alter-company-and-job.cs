namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class altercompanyandjob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.company", "seo_description", c => c.String());
            AlterColumn("dbo.company", "description", c => c.String());
            AlterColumn("dbo.job", "seo_description", c => c.String());
            AlterColumn("dbo.job", "job_requirement", c => c.String());
            AlterColumn("dbo.job", "description", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.job", "description", c => c.String(maxLength: 500));
            AlterColumn("dbo.job", "job_requirement", c => c.String(maxLength: 250));
            AlterColumn("dbo.job", "seo_description", c => c.String(maxLength: 500));
            AlterColumn("dbo.company", "description", c => c.String(maxLength: 500));
            AlterColumn("dbo.company", "seo_description", c => c.String(maxLength: 500));
        }
    }
}