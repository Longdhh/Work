namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altersecandtos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.security", "description", c => c.String());
            AlterColumn("dbo.term_of_service", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.term_of_service", "description", c => c.String(maxLength: 1000));
            AlterColumn("dbo.security", "description", c => c.String(maxLength: 1000));
        }
    }
}
