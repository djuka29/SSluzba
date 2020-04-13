namespace MasterApplication_SSluzbaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProfessorsclass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Professors", "ProfessorName", c => c.String(nullable: false));
            AlterColumn("dbo.Professors", "AcademicRank", c => c.String(nullable: false));
            AlterColumn("dbo.Professors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Professors", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Professors", "Address", c => c.String());
            AlterColumn("dbo.Professors", "Email", c => c.String());
            AlterColumn("dbo.Professors", "AcademicRank", c => c.String());
            AlterColumn("dbo.Professors", "ProfessorName", c => c.String());
        }
    }
}
