namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletetechnology : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.technology");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.technology",
                c => new
                    {
                        technology_id = c.Long(nullable: false, identity: true),
                        technology_name = c.String(maxLength: 100),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.technology_id);
            
        }
    }
}
