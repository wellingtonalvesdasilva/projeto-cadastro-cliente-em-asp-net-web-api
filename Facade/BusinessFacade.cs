using Arquitetura.Facade;
using Business;
using Model;

namespace Facade
{
    //Padrão facade e singleton
    public class BusinessFacade : BusinessFacadeBase<CadastroEntities>
    {
        private ClienteBusiness clienteBusiness;
        public ClienteBusiness Cliente
        {
            get { return clienteBusiness ?? (clienteBusiness = new ClienteBusiness()); }
        }

        public static BusinessFacade GetInstance()
        {
            return GetInstance<BusinessFacade>();
        }
    }
}
