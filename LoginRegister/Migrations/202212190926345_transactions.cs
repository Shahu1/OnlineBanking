namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transactions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transaction", "TransationAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transaction", "TransationAmount", c => c.String(nullable: false));
        }
    }
}
