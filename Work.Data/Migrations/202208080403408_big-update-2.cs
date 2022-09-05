namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigupdate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.company", "district_id", "dbo.district");
            DropForeignKey("dbo.job", "district_id", "dbo.district");
            DropIndex("dbo.company", new[] { "district_id" });
            DropIndex("dbo.job", new[] { "district_id" });
            CreateTable(
                "dbo.scale",
                c => new
                    {
                        scale_id = c.Long(nullable: false, identity: true),
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
                .PrimaryKey(t => t.scale_id);
            
            AddColumn("dbo.company", "country_id", c => c.Long());
            AddColumn("dbo.company", "scale_id", c => c.Long());
            CreateIndex("dbo.company", "country_id");
            CreateIndex("dbo.company", "scale_id");
            AddForeignKey("dbo.company", "country_id", "dbo.country", "country_id");
            AddForeignKey("dbo.company", "scale_id", "dbo.scale", "scale_id");
            DropColumn("dbo.company", "district_id");
            DropColumn("dbo.company", "address");
            DropColumn("dbo.job", "district_id");
            DropColumn("dbo.job", "address");
            DropColumn("dbo.job", "job_registed_user");
        }
        
        public override void Down()
        {
            AddColumn("dbo.job", "job_registed_user", c => c.Long(nullable: false));
            AddColumn("dbo.job", "address", c => c.String());
            AddColumn("dbo.job", "district_id", c => c.Long());
            AddColumn("dbo.company", "address", c => c.String());
            AddColumn("dbo.company", "district_id", c => c.Long());
            DropForeignKey("dbo.company", "scale_id", "dbo.scale");
            DropForeignKey("dbo.company", "country_id", "dbo.country");
            DropIndex("dbo.company", new[] { "scale_id" });
            DropIndex("dbo.company", new[] { "country_id" });
            DropColumn("dbo.company", "scale_id");
            DropColumn("dbo.company", "country_id");
            DropTable("dbo.scale");
            CreateIndex("dbo.job", "district_id");
            CreateIndex("dbo.company", "district_id");
            AddForeignKey("dbo.job", "district_id", "dbo.district", "district_id");
            AddForeignKey("dbo.company", "district_id", "dbo.district", "district_id");
        }
    }
}
