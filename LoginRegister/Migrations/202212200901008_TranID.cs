namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TranID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Transaction");
            AddColumn("dbo.Transaction", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Transaction", "Id");
            DropColumn("dbo.Transaction", "TransationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "TransationId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Transaction");
            DropColumn("dbo.Transaction", "Id");
            AddPrimaryKey("dbo.Transaction", "TransationId");
        }
    }
}
