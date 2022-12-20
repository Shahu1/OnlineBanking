namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccDetails : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Transaction");
            AlterColumn("dbo.Transaction", "TransationId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Transaction", "TransationId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Transaction");
            AlterColumn("dbo.Transaction", "TransationId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Transaction", "TransationId");
        }
    }
}
