namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class convertstatustype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.blog", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.blog", "status", c => c.String(nullable: false));
        }
    }
}
