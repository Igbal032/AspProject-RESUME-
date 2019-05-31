namespace AspFinalProject.Migrations
{
    using AspFinalProject.Models;
    using AspFinalProject.Models.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AspFinalProject.Models.myCvDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.myCvDbContext context)
        {

            try
            {
                if (!context.Person.Any())
                {
                    context.Person.AddRange(new[]
                    {
                        new Person
                        {
                             FullName = "Igbal Hasanli",
                              Age = 20,
                               Location = "Baku",
                                Experience = "5 Years",
                                 Email = "iqbal.hoff@list.ru",
                                  Website = "MyCV",
                                   Phone = "+994506705569",
                                     Password="11",
                                      Fax= "(800) 123-4568",
                                       Degree="MBA",
                                       imgPath="",
                                       CareerLevel="Hight",
                                        CreatedDate = DateTime.Now,
                        }

                    });
                }

                if (!context.SocialProfiles.Any())
                {
                    context.SocialProfiles.AddRange(new[] {

                    new SocialProfiles
                    {
                         Facebook="Facebook",
                           Skype="iqbalhasanli1",
                            LinkIN ="LinkIN",
                             Google="Google",
                    }

                });
                }

                if (!context.Category.Any())
                {
                    context.Category.AddRange(new[] {
                    new Category{
                        Name="Web Design",
                        CreatedDate=DateTime.Now
                    },
                    new Category{
                        Name="Development",
                        CreatedDate=DateTime.Now

                    },
                    new Category{
                        Name="Graphic Design",
                        CreatedDate=DateTime.Now
                    }
                         });
                }

                if (!context.TypeOfSkill.Any())
                {
                    context.TypeOfSkill.AddRange(new[] {
                    new TypeOfSkill{
                        Name="HTML 5",
                        CreatedDate=DateTime.Now
                    },
                    new TypeOfSkill{
                        Name="CSS",
                        CreatedDate=DateTime.Now

                    },
                    new TypeOfSkill{
                        Name="SASS",
                        CreatedDate=DateTime.Now
                    }
                        });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //private void GenerateTestData(myCvDbContext context)
        //{
        //    if (!context.Category.Any())
        //    {
        //        context.Category.AddRange(new[] {
        //            GenerateCategory("HTML 6"),
        //            GenerateCategory("SASS"),

        //        });
        //    }
        //}

        //    Category GenerateCategory(string name)
        //    {
        //        return new Category
        //        {
        //            Name = name,
        //            CreatedDate = DateTime.Now,
        //    };
        //}

    }
}
