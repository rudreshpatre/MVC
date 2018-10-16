namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes set Name = \'Pay as You Go \' where Id =1");
            Sql("Update MembershipTypes set Name = \'Monthly\' where Id =2");
            Sql("Update MembershipTypes set Name = \'Quaterly\' where Id =3");
            Sql("Update MembershipTypes set Name = \'Yearly\' where Id =4");
        }
        
        public override void Down()
        {
        }
    }
}
