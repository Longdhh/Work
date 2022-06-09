namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class alter_announcement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.announcement", "email", c => c.String());
            AddColumn("dbo.announcement", "phone_number", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.announcement", "phone_number");
            DropColumn("dbo.announcement", "email");
        }
    }
}