namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeavatar : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.blog", "avatar", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.blog", "avatar", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
