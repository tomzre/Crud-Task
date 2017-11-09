namespace CrudTT.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressTableFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
