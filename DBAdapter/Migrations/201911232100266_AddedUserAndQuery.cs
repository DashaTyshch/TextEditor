namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserAndQuery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Query",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        QueryDate = c.DateTime(nullable: false),
                        FilePath = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        User_Guid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .ForeignKey("dbo.Users", t => t.User_Guid, cascadeDelete: true)
                .Index(t => t.User_Guid);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Guid = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        Login = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Guid)
                .Index(t => new { t.Email, t.Login }, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Query", "User_Guid", "dbo.Users");
            DropIndex("dbo.Users", new[] { "Email", "Login" });
            DropIndex("dbo.Query", new[] { "User_Guid" });
            DropTable("dbo.Users");
            DropTable("dbo.Query");
        }
    }
}
