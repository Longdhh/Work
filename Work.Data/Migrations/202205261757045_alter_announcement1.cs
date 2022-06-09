namespace Work.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class alter_announcement1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.announcement", "resume", c => c.String());
            AddColumn("dbo.company", "phone_number", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.company", "phone_number");
            DropColumn("dbo.announcement", "resume");
        }
    }
}