namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfShortDescriptionOnTablePost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String(maxLength: 200));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "ShortDescription", c => c.String(maxLength: 50));
        }
    }
}
