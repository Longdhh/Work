namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mergetosandsecurity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.public_text",
                c => new
                    {
                        public_text_id = c.Long(nullable: false, identity: true),
                        description = c.String(),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.public_text_id);
            
            DropTable("dbo.security");
            DropTable("dbo.term_of_service");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.term_of_service",
                c => new
                    {
                        tos_id = c.Long(nullable: false, identity: true),
                        description = c.String(),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.tos_id);
            
            CreateTable(
                "dbo.security",
                c => new
                    {
                        security_id = c.Long(nullable: false, identity: true),
                        description = c.String(),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.security_id);
            
            DropTable("dbo.public_text");
        }
    }
}
