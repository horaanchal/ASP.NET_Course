namespace Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
           // Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES (1,0,0,0)");
            //Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES (2,30,1,10)");
            //Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES (3,90,3,15)");
            //Sql("INSERT INTO MembershipTypes (Id, SignUpFree, DurationInMonths, DiscountRate) VALUES (4,300,12,20)");
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
