namespace XrmLite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickListValue : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PickListValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelType = c.String(maxLength: 4000),
                        FieldName = c.String(maxLength: 4000),
                        Values = c.String(maxLength: 4000),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 4000),
                        LastModifiedDate = c.DateTime(),
                        LastModifiedBy = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PickListValues");
        }
    }
}
