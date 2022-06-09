namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class createsignalr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.announcement_user",
                c => new
                {
                    announcement_id = c.Int(nullable: false),
                    id = c.String(nullable: false, maxLength: 128),
                    has_read = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.announcement_id, t.id })
                .ForeignKey("dbo.announcement", t => t.announcement_id)
                .ForeignKey("dbo.AspNetUsers", t => t.id)
                .Index(t => t.announcement_id)
                .Index(t => t.id);

            CreateTable(
                "dbo.announcement",
                c => new
                {
                    announcement_id = c.Int(nullable: false, identity: true),
                    title = c.String(nullable: false, maxLength: 250),
                    content = c.String(),
                    created_at = c.DateTime(nullable: false),
                    Id = c.String(maxLength: 128),
                    status = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.announcement_id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .Index(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.announcement_user", "id", "dbo.AspNetUsers");
            DropForeignKey("dbo.announcement", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.announcement_user", "announcement_id", "dbo.announcement");
            DropIndex("dbo.announcement", new[] { "Id" });
            DropIndex("dbo.announcement_user", new[] { "id" });
            DropIndex("dbo.announcement_user", new[] { "announcement_id" });
            DropTable("dbo.announcement");
            DropTable("dbo.announcement_user");
        }
    }
}