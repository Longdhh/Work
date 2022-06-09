namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class addwelfare : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.welfare",
                c => new
                {
                    welfare_id = c.Long(nullable: false, identity: true),
                    job_id = c.Long(nullable: false),
                    welfare_type_id = c.Long(nullable: false),
                    description = c.String(maxLength: 200),
                })
                .PrimaryKey(t => t.welfare_id)
                .ForeignKey("dbo.job", t => t.job_id)
                .ForeignKey("dbo.welfare_type", t => t.welfare_type_id)
                .Index(t => t.job_id)
                .Index(t => t.welfare_type_id);

            DropColumn("dbo.job", "welfare");
        }

        public override void Down()
        {
            AddColumn("dbo.job", "welfare", c => c.String());
            DropForeignKey("dbo.welfare", "welfare_type_id", "dbo.welfare_type");
            DropForeignKey("dbo.welfare", "job_id", "dbo.job");
            DropIndex("dbo.welfare", new[] { "welfare_type_id" });
            DropIndex("dbo.welfare", new[] { "job_id" });
            DropTable("dbo.welfare");
        }
    }
}