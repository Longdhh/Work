namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfourtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.blog_category",
                c => new
                    {
                        blog_category_id = c.Long(nullable: false, identity: true),
                        seo_alias = c.String(nullable: false, maxLength: 200),
                        name = c.String(nullable: false, maxLength: 200),
                        seo_title = c.String(maxLength: 200),
                        seo_description = c.String(maxLength: 200),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.blog_category_id);
            
            CreateTable(
                "dbo.blog",
                c => new
                    {
                        blog_id = c.Long(nullable: false, identity: true),
                        description = c.String(),
                        seo_alias = c.String(nullable: false, maxLength: 200),
                        name = c.String(nullable: false, maxLength: 200),
                        seo_title = c.String(maxLength: 200),
                        seo_description = c.String(maxLength: 1000),
                        blog_category_id = c.Long(),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.blog_id)
                .ForeignKey("dbo.blog_category", t => t.blog_category_id)
                .Index(t => t.blog_category_id);
            
            CreateTable(
                "dbo.country",
                c => new
                    {
                        country_id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 200),
                        flag = c.String(maxLength: 200),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.country_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.blog", "blog_category_id", "dbo.blog_category");
            DropIndex("dbo.blog", new[] { "blog_category_id" });
            DropTable("dbo.country");
            DropTable("dbo.blog");
            DropTable("dbo.blog_category");
        }
    }
}
