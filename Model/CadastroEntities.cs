using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Model
{
    public class CadastroEntities : DbContext
    {
        public CadastroEntities(string connectionString) : base(connectionString)
        { }

        public CadastroEntities() : base("name=CadastroEntities")
        { }

        public CadastroEntities(DbConnection connection) : base(connection, true)
        { }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove pluralizacao
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //padroniza todos os campos string para varchar(60)
            //modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            //modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(60));
        }
    }
}
