namespace CapgeminiCrudTEST.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerTableFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            RenameColumn(table: "dbo.Customers", name: "Address_Id", newName: "AddressId");
            AlterColumn("dbo.Customers", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AddressId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            AlterColumn("dbo.Customers", "AddressId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "AddressId", newName: "Address_Id");
            CreateIndex("dbo.Customers", "Address_Id");
            AddForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
