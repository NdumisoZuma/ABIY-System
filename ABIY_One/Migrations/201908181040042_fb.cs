namespace ABIY_One.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feedbacks",
                c => new
                    {
                        Feed_ID = c.Int(nullable: false, identity: true),
                        Answer = c.Int(),
                        Comment = c.String(maxLength: 500),
                        FullName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 225),
                    })
                .PrimaryKey(t => t.Feed_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Feedbacks");
        }
    }
}
