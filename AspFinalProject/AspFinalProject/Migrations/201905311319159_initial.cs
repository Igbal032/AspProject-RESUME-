namespace AspFinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicBackgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.String(),
                        Degree = c.String(),
                        UniversityName = c.String(),
                        YearOfObtention = c.String(),
                        Details = c.String(),
                        imgPathAc = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FromEmail = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                        SendingDate = c.DateTime(nullable: false),
                        Answer = c.String(),
                        isAnswered = c.Boolean(nullable: false),
                        isRead = c.Boolean(nullable: false),
                        DeletedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        ErrorCode = c.Int(),
                        ErrorMessage = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Location = c.String(),
                        Experience = c.String(),
                        Degree = c.String(),
                        CareerLevel = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Phone = c.String(),
                        Website = c.String(),
                        imgPath = c.String(),
                        Password = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessionalExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        CompanyName = c.String(),
                        Location = c.String(),
                        Details = c.String(),
                        Duration = c.String(),
                        imgPath = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        YourDescription = c.String(),
                        SkillLevel = c.Int(),
                        SkillDescription = c.String(),
                        DisplayAsBar = c.Boolean(),
                        DisplayAsTag = c.Boolean(),
                        TypeOfSkill = c.String(),
                        Category = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SocialProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Facebook = c.String(),
                        Google = c.String(),
                        Skype = c.String(),
                        LinkIN = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeOfSkills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedId = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedId = c.Int(),
                        DeletedDate = c.DateTime(),
                        DeletedId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeOfSkills");
            DropTable("dbo.SocialProfiles");
            DropTable("dbo.Skills");
            DropTable("dbo.ProfessionalExperiences");
            DropTable("dbo.People");
            DropTable("dbo.ErrorHistories");
            DropTable("dbo.Contacts");
            DropTable("dbo.Categories");
            DropTable("dbo.AcademicBackgrounds");
        }
    }
}
