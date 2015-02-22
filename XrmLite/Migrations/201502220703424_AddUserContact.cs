namespace XrmLite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ContactId", c => c.Int());
            CreateIndex("dbo.Users", "ContactId");
            AddForeignKey("dbo.Users", "ContactId", "dbo.Contacts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Users", new[] { "ContactId" });
            DropColumn("dbo.Users", "ContactId");
        }
    }
}
