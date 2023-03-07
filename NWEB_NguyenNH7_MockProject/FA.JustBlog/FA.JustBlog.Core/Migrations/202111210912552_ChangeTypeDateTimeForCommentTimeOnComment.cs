namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeDateTimeForCommentTimeOnComment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentTime", c => c.String());
        }
    }
}
