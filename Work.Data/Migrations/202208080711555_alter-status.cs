namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.job", "job_registed_user", c => c.Long(nullable: false));
            AlterColumn("dbo.blog", "status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.blog", "status", c => c.Boolean(nullable: false));
            DropColumn("dbo.job", "job_registed_user");
        }
    }
}
