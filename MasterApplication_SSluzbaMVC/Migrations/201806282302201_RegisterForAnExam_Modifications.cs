namespace MasterApplication_SSluzbaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterForAnExam_Modifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterForAnExams", "ExamRoom", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterForAnExams", "ExamRoom", c => c.String());
        }
    }
}
