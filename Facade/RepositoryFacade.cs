using Arquitetura.Facade;
using Arquitetura.Repository;
using Model;

namespace Facade
{
    //Padrão facade e singleton
    public class RepositoryFacade: RepositoryFacadeBase<CadastroEntities>
    {
        //Poderia substitui isso por um método da super classe

        private GenericRepository<CadastroEntities, Cliente> clienteRepository;
        public GenericRepository<CadastroEntities, Cliente> Cliente
        {
            get { return clienteRepository ?? (clienteRepository = new GenericRepository<CadastroEntities, Cliente>()); }
        }

        public static RepositoryFacade GetInstance()
        {
            return GetInstance<RepositoryFacade>();
        }
    }
}
