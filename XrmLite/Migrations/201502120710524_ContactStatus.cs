namespace XrmLite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContactStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Status", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Status");
        }
    }
}
