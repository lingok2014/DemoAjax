namespace Demo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenNhanVien = c.String(nullable: false, maxLength: 255),
                        DiaChi = c.String(nullable: false, maxLength: 255),
                        SoDienThoai = c.String(maxLength: 12, unicode: false),
                        Email = c.String(nullable: false, maxLength: 255, unicode: false),
                        Tuoi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanVien");
        }
    }
}
