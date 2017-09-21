namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 15),
                        Nome = c.String(nullable: false, maxLength: 60),
                        CPF_CNPJ = c.String(nullable: false, maxLength: 14),
                        Telefone = c.String(nullable: false, maxLength: 11),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cliente");
        }
    }
}
