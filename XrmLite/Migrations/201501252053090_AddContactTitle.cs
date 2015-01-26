namespace XrmLite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Title", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "Title");
        }
    }
}
