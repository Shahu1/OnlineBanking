namespace LoginRegister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        AadharNumber = c.String(nullable: false, maxLength: 12),
                        DateofBirth = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Occupation = c.String(nullable: false),
                        AnnualIncome = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        TransationId = c.String(nullable: false, maxLength: 128),
                        AccountNumber = c.Int(nullable: false),
                        PayeeAccountNo = c.Int(nullable: false),
                        TransationAmount = c.String(nullable: false),
                        TransactionType = c.String(),
                        TransactionDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TransationId)
                .ForeignKey("dbo.Users", t => t.AccountNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transaction", "AccountNumber", "dbo.Users");
            DropForeignKey("dbo.AccountDetails", "AccountNumber", "dbo.Users");
            DropIndex("dbo.Transaction", new[] { "AccountNumber" });
            DropIndex("dbo.AccountDetails", new[] { "AccountNumber" });
            DropTable("dbo.Transaction");
            DropTable("dbo.Users");
            DropTable("dbo.AccountDetails");
        }
    }
}
