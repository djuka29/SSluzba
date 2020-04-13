namespace MasterApplication_SSluzbaMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Subjectmodification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Semestre", c => c.String(nullable: false, maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Semestre", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
