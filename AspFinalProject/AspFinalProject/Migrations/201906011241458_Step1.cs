namespace AspFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Step1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Skills", "DisplayAsBar", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Skills", "DisplayAsTag", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skills", "DisplayAsTag", c => c.Boolean());
            AlterColumn("dbo.Skills", "DisplayAsBar", c => c.Boolean());
        }
    }
}
