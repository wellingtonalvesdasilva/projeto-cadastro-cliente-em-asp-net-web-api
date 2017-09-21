using Arquitetura;
using Arquitetura.Business;
using Business.Excecao;
using Model;
using Util;

namespace Business
{
    public class ClienteBusiness : BusinessCrudGeneric<CadastroEntities, Cliente>
    {
        protected override void ValidarRegrasDeNegocio(Cliente cliente, ECrudOperacao operacao)
        {
            if(operacao == ECrudOperacao.Criar)
            {
                if (repository.GetUnique(c => c.CPF_CNPJ.Equals(cliente.CPF_CNPJ)) != null)
                    throw new ExcecaoRegraDeNegocio.EmCliente.ClienteJaCadastradoComEsseCPFOuCNPJ();
            }
            else if (operacao == ECrudOperacao.Editar)
            {
                if (repository.GetUnique(c => c.CPF_CNPJ.Equals(cliente.CPF_CNPJ) && c.Id != cliente.Id) != null)
                    throw new ExcecaoRegraDeNegocio.EmCliente.ClienteJaCadastradoComEsseCPFOuCNPJ();
            }
        }

        protected override Cliente IncluirModel(Cliente cliente, bool salvarAlteracoes = true)
        {
            cliente.Status = (int)Enumeracao.ESituacao.Ativo;
            return base.IncluirModel(cliente, salvarAlteracoes);
        }

    }
}
