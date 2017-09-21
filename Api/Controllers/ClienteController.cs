using Api.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Api.Controllers
{
    [RoutePrefix("api/cliente")]
    public class ClienteController : ApiBaseController<CadastroEntities, Cliente, ClienteEnvelope>
    {
        /// <summary>
        /// Consultar Todos
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(IEnumerable<ClienteEnvelope>))]
        public HttpResponseMessage Get()
        {
            return Ok(MapperEntityToPoco(this.Repository.GetAll().ToList()));
        }

        /// <summary>
        /// Consultar por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(ClienteEnvelope))]
        public HttpResponseMessage Get(long id)
        {
            var cliente = this.Repository.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(MapperEntityToPoco(cliente));
        }


        /// <summary>
        /// Deletar um registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(ClienteEnvelope))]
        public HttpResponseMessage Delete(long id)
        {
            var cliente = Repository.GetById(id);

            if (cliente == null)
                return NotFound();

            BusinessFacade.Cliente.Excluir(cliente);

            return Ok(MapperEntityToPoco(cliente));
        }

        /// <summary>
        /// Criar um registro
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        [Route("")]
        [ResponseType(typeof(ClienteEnvelope))]
        public HttpResponseMessage Post([FromBody] ClienteEnvelope cliente)
        {
            if (cliente == null)
                return BadRequest();

            var clienteRegistrado = BusinessFacade.Cliente.Incluir(MapperPocoToEntity(cliente));

            return Ok(MapperEntityToPoco(clienteRegistrado));
        }

        /// <summary>
        /// Atualizar um registro
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [ResponseType(typeof(ClienteEnvelope))]
        public HttpResponseMessage Put([FromBody] ClienteEnvelope cliente, long id)
        {
            if (Repository.GetById(id) == null)
                return NotFound();

            if (cliente == null)
                return BadRequest();

            var clienteAlterado = MapperPocoToEntity(cliente);

            BusinessFacade.Cliente.Editar(clienteAlterado);

            return Ok(MapperEntityToPoco(clienteAlterado));
        }

        [Route("porNome")]
        [ResponseType(typeof(IEnumerable<ClienteEnvelope>))]
        public HttpResponseMessage Get(string nome)
        {
            return Ok(MapperEntityToPoco(this.Repository.Find(c => c.Nome.ToLower().Contains(nome.ToLower())).ToList()));
        }
    }
}
