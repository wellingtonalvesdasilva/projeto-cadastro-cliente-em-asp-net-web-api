using Arquitetura.Excecao;
using Business.Excecao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;

namespace Teste
{
    [TestClass]
    public class ClienteBusinessTest : TestsBase
    {
        [TestMethod]
        public void NaoDeveInserirNaBaseQuandoTodosOsCamposObrigatoriosNaoForamPreenchidos()
        {
            var qtdeDeCamposNaoPreenchidos = 4;

            try
            {
                BusinessFacade.Cliente.Incluir(new Cliente());
            }
            catch (ExcecaoCampoObrigatorio ex)
            {
                Assert.AreEqual(qtdeDeCamposNaoPreenchidos, ex.Excecoes.Count, "Deve ter " + qtdeDeCamposNaoPreenchidos + " não prenchidos");
            }

        }

        [TestMethod]
        public void NaoDeveInserirNaBaseEnquantoTodosOsCamposObrigatoriosNaoForamPreenchidos()
        {
            var qtdeDeCamposNaoPreenchidos = 2;

            try
            {
                BusinessFacade.Cliente.Incluir(new Cliente
                {
                    Nome = "Wellington Alves",
                    Telefone = "67992971718"
                });
            }
            catch (ExcecaoCampoObrigatorio ex)
            {
                Assert.AreEqual(qtdeDeCamposNaoPreenchidos, ex.Excecoes.Count, "Deve ter " + qtdeDeCamposNaoPreenchidos + " não prenchidos");
            }

        }

        [TestMethod]
        public void DeveInserirNaBaseQuandoTodosOsCamposObrigatoriosForamPreenchidos()
        {
            var clienteASerRegistrado = FabricaDeDados.MontarCliente();

            BusinessFacade.Cliente.Incluir(clienteASerRegistrado);

            var clienteRegistrado = RepositoryFacade.Cliente.GetAll().First();

            Assert.IsNotNull(clienteRegistrado, "Cliente não pode ser nulo");
            Assert.AreEqual(clienteASerRegistrado.Nome, clienteRegistrado.Nome);
            Assert.AreEqual(clienteASerRegistrado.Codigo, clienteRegistrado.Codigo);
            Assert.AreEqual(clienteASerRegistrado.CPF_CNPJ, clienteRegistrado.CPF_CNPJ);
            Assert.AreEqual(clienteASerRegistrado.Telefone, clienteRegistrado.Telefone);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoRegraDeNegocio.EmCliente.ClienteJaCadastradoComEsseCPFOuCNPJ))]
        public void NaoDeveInserirNaBaseQuandoOClienteJaTerSidoCadastrado()
        {
            var clienteASerRegistrado = FabricaDeDados.MontarCliente();

            var clienteRegistrado = BusinessFacade.Cliente.Incluir(clienteASerRegistrado);

            Assert.IsNotNull(clienteRegistrado, "Cliente não pode ser nulo");
            Assert.AreEqual(clienteASerRegistrado.CPF_CNPJ, clienteRegistrado.CPF_CNPJ);

            //não é possivel incluir um cliente com o mesmo CPF do que já está registrado
            BusinessFacade.Cliente.Incluir(clienteASerRegistrado);
        }

        [TestMethod]
        public void DeveGarantirQueAoAlterarOClienteEstejaNaBaseComAsMesmasInformacoes()
        {
            var clienteASerRegistrado = FabricaDeDados.MontarCliente();

            BusinessFacade.Cliente.Incluir(clienteASerRegistrado);

            var clienteRegistrado = RepositoryFacade.Cliente.GetAll().First();

            Assert.IsNotNull(clienteRegistrado, "Cliente não pode ser nulo");
            Assert.AreEqual(clienteASerRegistrado.Nome, clienteRegistrado.Nome);
            Assert.AreEqual(clienteASerRegistrado.Codigo, clienteRegistrado.Codigo);
            Assert.AreEqual(clienteASerRegistrado.CPF_CNPJ, clienteRegistrado.CPF_CNPJ);
            Assert.AreEqual(clienteASerRegistrado.Telefone, clienteRegistrado.Telefone);

            clienteRegistrado.Telefone = "67999999999";

            BusinessFacade.Cliente.Editar(clienteASerRegistrado);

            var clienteAlterado = RepositoryFacade.Cliente.GetAll().First();

            Assert.AreEqual(clienteRegistrado.Nome, clienteAlterado.Nome);
            Assert.AreEqual(clienteRegistrado.Codigo, clienteAlterado.Codigo);
            Assert.AreEqual(clienteRegistrado.CPF_CNPJ, clienteAlterado.CPF_CNPJ);
            Assert.AreEqual(clienteRegistrado.Telefone, clienteAlterado.Telefone);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcecaoRegraDeNegocio.EmCliente.ClienteJaCadastradoComEsseCPFOuCNPJ))]
        public void NaoDeveAlterarClienteQuandoAsInformacoesJaPossueremNaBaseEmOutroRegistro()
        {
            var cliente1 = FabricaDeDados.MontarCliente();
            var clienteRegistrado1 = BusinessFacade.Cliente.Incluir(cliente1);

            var cliente2 = FabricaDeDados.MontarCliente(cpfCnpj: "02604211114");
            var clienteRegistrado2 = BusinessFacade.Cliente.Incluir(cliente2);

            //alterado o registro do cliente para o mesmo cpf, ou seja é a mesma pessoa, logo não pode ser possivel a edição
            clienteRegistrado2.CPF_CNPJ = clienteRegistrado1.CPF_CNPJ;

            BusinessFacade.Cliente.Editar(clienteRegistrado2);
        }

        [TestMethod]
        public void DeveGarantirQueAoExcluirOClienteNaoEstejaMaisNaBase()
        {
            var clienteASerRegistrado = FabricaDeDados.MontarCliente();

            BusinessFacade.Cliente.Incluir(clienteASerRegistrado);

            Assert.AreEqual(1, RepositoryFacade.Cliente.GetAll().Count(), "Cliente deveria estar na base");

            BusinessFacade.Cliente.Excluir(clienteASerRegistrado);

            Assert.AreEqual(0, RepositoryFacade.Cliente.GetAll().Count(), "Cliente não deveria estar na base");
        }

        [TestMethod]
        public void DeveGarantirQueAoIncluirVariosClientesOsMesmosSejamListados()
        {
            var cliente1 = FabricaDeDados.MontarCliente();
            BusinessFacade.Cliente.Incluir(cliente1);
            Assert.AreEqual(1, RepositoryFacade.Cliente.GetAll().Count());

            var cliente2 = FabricaDeDados.MontarCliente(cpfCnpj: "02604211114");
            BusinessFacade.Cliente.Incluir(cliente2);
            Assert.AreEqual(2, RepositoryFacade.Cliente.GetAll().Count());

            var cliente3 = FabricaDeDados.MontarCliente(cpfCnpj: "02604211115");
            BusinessFacade.Cliente.Incluir(cliente3);
            Assert.AreEqual(3, RepositoryFacade.Cliente.GetAll().Count());
        }
    }
}
