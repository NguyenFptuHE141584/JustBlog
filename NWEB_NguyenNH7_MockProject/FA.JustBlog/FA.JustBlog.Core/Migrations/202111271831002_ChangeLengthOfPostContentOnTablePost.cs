namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLengthOfPostContentOnTablePost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
