namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountDetails", "PayeeAccount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountDetails", "PayeeAccount");
        }
    }
}
