namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterjob : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.job", "created_by", c => c.String());
            AlterColumn("dbo.job", "modified_by", c => c.String());
            AlterColumn("dbo.job", "status", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.job", "status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.job", "modified_by", c => c.String(maxLength: 200));
            AlterColumn("dbo.job", "created_by", c => c.String(maxLength: 200));
        }
    }
}
