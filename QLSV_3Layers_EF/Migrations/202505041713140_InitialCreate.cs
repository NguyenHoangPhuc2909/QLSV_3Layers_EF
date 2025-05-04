namespace QLSV_3Layers_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diem",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        MSSV = c.String(nullable: false, maxLength: 50),
                        CourseId = c.Int(nullable: false),
                        Score = c.Double(nullable: false),
                        Semester = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.GradeId)
                .ForeignKey("dbo.MonHoc", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.SinhVien", t => t.MSSV, cascadeDelete: true)
                .Index(t => t.MSSV)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.MonHoc",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 20),
                        CourseName = c.String(nullable: false, maxLength: 100),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .Index(t => t.CourseCode, unique: true);
            
            CreateTable(
                "dbo.SinhVien",
                c => new
                    {
                        MSSV = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 100),
                        ClassId = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                        Username = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MSSV)
                .ForeignKey("dbo.LSHes", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Nguoidungs", t => t.MSSV)
                .Index(t => t.MSSV)
                .Index(t => t.ClassId);
            
            CreateTable(
                "dbo.LSHes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ClassId)
                .Index(t => t.ClassName, unique: true);
            
            CreateTable(
                "dbo.Nguoidungs",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 255),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Role = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Username)
                .Index(t => t.Username, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhVien", "MSSV", "dbo.Nguoidungs");
            DropForeignKey("dbo.Diem", "MSSV", "dbo.SinhVien");
            DropForeignKey("dbo.SinhVien", "ClassId", "dbo.LSHes");
            DropForeignKey("dbo.Diem", "CourseId", "dbo.MonHoc");
            DropIndex("dbo.Nguoidungs", new[] { "Username" });
            DropIndex("dbo.LSHes", new[] { "ClassName" });
            DropIndex("dbo.SinhVien", new[] { "ClassId" });
            DropIndex("dbo.SinhVien", new[] { "MSSV" });
            DropIndex("dbo.MonHoc", new[] { "CourseCode" });
            DropIndex("dbo.Diem", new[] { "CourseId" });
            DropIndex("dbo.Diem", new[] { "MSSV" });
            DropTable("dbo.Nguoidungs");
            DropTable("dbo.LSHes");
            DropTable("dbo.SinhVien");
            DropTable("dbo.MonHoc");
            DropTable("dbo.Diem");
        }
    }
}
