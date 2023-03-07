namespace FA.JustBlog.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ViewCount", c => c.Int());
            AddColumn("dbo.Posts", "RateCount", c => c.Int());
            AddColumn("dbo.Posts", "TotalRate", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "TotalRate");
            DropColumn("dbo.Posts", "RateCount");
            DropColumn("dbo.Posts", "ViewCount");
        }
    }
}
