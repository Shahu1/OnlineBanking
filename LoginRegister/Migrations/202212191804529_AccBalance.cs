namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccBalance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "AccBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transaction", "PayeeBalance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "PayeeBalance");
            DropColumn("dbo.Transaction", "AccBalance");
        }
    }
}
