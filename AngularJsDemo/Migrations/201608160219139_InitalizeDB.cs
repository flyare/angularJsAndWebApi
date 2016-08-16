namespace AngularJsDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalizeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Category = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
