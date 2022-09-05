namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterremovetitle : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.security", "title");
            DropColumn("dbo.term_of_service", "title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.term_of_service", "title", c => c.String(maxLength: 200));
            AddColumn("dbo.security", "title", c => c.String(maxLength: 200));
        }
    }
}
