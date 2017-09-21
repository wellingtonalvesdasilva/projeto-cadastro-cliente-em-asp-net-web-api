using Arquitetura.Excecao;
using System;

namespace Business.Excecao
{
    public partial class ExcecaoRegraDeNegocio : BusinessException
    {
        private ExcecaoRegraDeNegocio(string mensagem) : base(mensagem) { }

        [Serializable]
        public class EmCliente : ExcecaoRegraDeNegocio
        {
            private EmCliente(string mensagem) : base(mensagem) { }

            [Serializable]
            public class ClienteJaCadastradoComEsseCPFOuCNPJ : EmCliente
            {
                public ClienteJaCadastradoComEsseCPFOuCNPJ() : base("Já existe um cliente cadastrado com esse CPF/CNPJ")
                { }
            }
        }
    }
}
