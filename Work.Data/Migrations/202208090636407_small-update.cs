namespace Work.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.company", "province_id", "dbo.province");
            DropForeignKey("dbo.job", "province_id", "dbo.province");
            DropIndex("dbo.company", new[] { "province_id" });
            DropIndex("dbo.job", new[] { "province_id" });
            DropColumn("dbo.company", "province_id");
            DropColumn("dbo.job", "province_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.job", "province_id", c => c.Long());
            AddColumn("dbo.company", "province_id", c => c.Long());
            CreateIndex("dbo.job", "province_id");
            CreateIndex("dbo.company", "province_id");
            AddForeignKey("dbo.job", "province_id", "dbo.province", "province_id");
            AddForeignKey("dbo.company", "province_id", "dbo.province", "province_id");
        }
    }
}
