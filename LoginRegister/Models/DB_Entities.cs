using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LoginRegister.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LoginRegister.Models
{
    public class DB_Entities: DbContext
    {
        
        public DB_Entities() : base("DatabaseMVC5") { }
        public DbSet<User> User { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<demoEntities>(null);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);


        }

        //for transaction
        

        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<AccountDetails> AccountDetails { get; set; }   
        
    }
}
    