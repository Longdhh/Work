namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bigupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.district",
                c => new
                    {
                        district_id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 200),
                        province_id = c.Long(nullable: false),
                        created_at = c.DateTime(),
                        created_by = c.String(maxLength: 200),
                        modified_at = c.DateTime(),
                        modified_by = c.String(maxLength: 200),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.district_id)
                .ForeignKey("dbo.province", t => t.province_id)
                .Index(t => t.province_id);
            
            AddColumn("dbo.company", "district_id", c => c.Long());
            AddColumn("dbo.job", "district_id", c => c.Long());
            CreateIndex("dbo.company", "district_id");
            CreateIndex("dbo.job", "district_id");
            AddForeignKey("dbo.company", "district_id", "dbo.district", "district_id");
            AddForeignKey("dbo.job", "district_id", "dbo.district", "district_id");
            DropColumn("dbo.category", "category_logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.category", "category_logo", c => c.String(maxLength: 250));
            DropForeignKey("dbo.job", "district_id", "dbo.district");
            DropForeignKey("dbo.company", "district_id", "dbo.district");
            DropForeignKey("dbo.district", "province_id", "dbo.province");
            DropIndex("dbo.job", new[] { "district_id" });
            DropIndex("dbo.district", new[] { "province_id" });
            DropIndex("dbo.company", new[] { "district_id" });
            DropColumn("dbo.job", "district_id");
            DropColumn("dbo.company", "district_id");
            DropTable("dbo.district");
        }
    }
}
