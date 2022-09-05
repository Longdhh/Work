namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.public_text", "title", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.public_text", "title");
        }
    }
}
