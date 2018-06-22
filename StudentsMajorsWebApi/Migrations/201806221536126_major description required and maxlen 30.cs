namespace StudentsMajorsWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class majordescriptionrequiredandmaxlen30 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Majors", "Description", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Majors", "Description", c => c.String());
        }
    }
}
