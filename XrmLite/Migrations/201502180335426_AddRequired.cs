namespace XrmLite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequired : DbMigration
    {
        public override void Up()
        {

            AlterColumn("dbo.Contacts", "FirstName", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {

            AlterColumn("dbo.Contacts", "FirstName", c => c.String(maxLength: 4000));
        }
    }
}
