namespace MasterApplication_SSluzbaMVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Subjectmodelmodification : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subjects", "Semestre", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subjects", "Semestre", c => c.String(nullable: false));
        }
    }
}
