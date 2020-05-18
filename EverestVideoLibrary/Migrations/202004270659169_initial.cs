namespace EverestVideoLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Artists", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Artists", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Members", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Members", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Producers", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Producers", "LastName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Artists", "Name");
            DropColumn("dbo.Members", "Name");
            DropColumn("dbo.Producers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Producers", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Artists", "Name", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Producers", "LastName");
            DropColumn("dbo.Producers", "FirstName");
            DropColumn("dbo.Members", "LastName");
            DropColumn("dbo.Members", "FirstName");
            DropColumn("dbo.Artists", "LastName");
            DropColumn("dbo.Artists", "FirstName");
        }
    }
}
