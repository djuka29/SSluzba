namespace MasterApplication_SSluzbaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false),
                        DepartmentCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.ExamPeriods",
                c => new
                    {
                        ExamPeriodID = c.Int(nullable: false, identity: true),
                        ExamPeriodName = c.String(nullable: false),
                        BegginngOfExamPeriod = c.DateTime(nullable: false),
                        EndingOfExamPeriod = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExamPeriodID);
            
            CreateTable(
                "dbo.Professors",
                c => new
                    {
                        ProfessorID = c.Int(nullable: false, identity: true),
                        ProfessorName = c.String(),
                        AcademicRank = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorID);
            
            CreateTable(
                "dbo.RegisterForAnExams",
                c => new
                    {
                        RegisterForAnExamID = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(nullable: false),
                        ExamRoom = c.String(),
                        DepartmentID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        ProfessorID = c.Int(nullable: false),
                        SubjectID = c.Int(nullable: false),
                        ExamPeriodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegisterForAnExamID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.ExamPeriods", t => t.ExamPeriodID, cascadeDelete: true)
                .ForeignKey("dbo.Professors", t => t.ProfessorID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .Index(t => t.DepartmentID)
                .Index(t => t.StudentID)
                .Index(t => t.ProfessorID)
                .Index(t => t.SubjectID)
                .Index(t => t.ExamPeriodID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false),
                        IndexNumber = c.String(nullable: false),
                        StudentDOB = c.DateTime(nullable: false),
                        YearOfStudies = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsBudget = c.Boolean(nullable: false),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.StudentID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectID = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false),
                        SubjectCode = c.String(nullable: false),
                        Semestre = c.String(nullable: false),
                        ESPB = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RegisterForAnExams", "SubjectID", "dbo.Subjects");
            DropForeignKey("dbo.RegisterForAnExams", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.RegisterForAnExams", "ProfessorID", "dbo.Professors");
            DropForeignKey("dbo.RegisterForAnExams", "ExamPeriodID", "dbo.ExamPeriods");
            DropForeignKey("dbo.RegisterForAnExams", "DepartmentID", "dbo.Departments");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Students", new[] { "DepartmentID" });
            DropIndex("dbo.RegisterForAnExams", new[] { "ExamPeriodID" });
            DropIndex("dbo.RegisterForAnExams", new[] { "SubjectID" });
            DropIndex("dbo.RegisterForAnExams", new[] { "ProfessorID" });
            DropIndex("dbo.RegisterForAnExams", new[] { "StudentID" });
            DropIndex("dbo.RegisterForAnExams", new[] { "DepartmentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.RegisterForAnExams");
            DropTable("dbo.Professors");
            DropTable("dbo.ExamPeriods");
            DropTable("dbo.Departments");
        }
    }
}
