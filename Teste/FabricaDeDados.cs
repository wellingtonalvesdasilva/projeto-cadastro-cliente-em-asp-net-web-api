using Facade;
using Model;

namespace Teste
{
    public class FabricaDeDados
    {
        private BusinessFacade BusinessFacade => BusinessFacade.GetInstance();
        private RepositoryFacade RepositoryFacade => RepositoryFacade.GetInstance();

        public Cliente MontarCliente(string nome = "Wellington Alves da Silva", string codigo = "cod1" , string cpfCnpj = "02604212196", string telefone = "67992971718")
        {
            return new Cliente
            {
                Nome = nome,
                Codigo = codigo,
                CPF_CNPJ = cpfCnpj,
                Telefone = telefone
            };
        }
    }
}
