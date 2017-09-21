using Arquitetura.Entity;
using Arquitetura.Mapeamento;
using Arquitetura.Repository;
using Facade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class ApiBaseController<TContext, TEntity, TPoco> : ApiController
        where TContext : DbContext, new()
        where TEntity : class
        where TPoco : class
    {
        public RepositoryFacade RepositoryFacade => RepositoryFacade.GetInstance();

        public BusinessFacade BusinessFacade => BusinessFacade.GetInstance();

        protected GenericRepository<TContext, TEntity> Repository;

        protected VirtualMapping<TEntity, TPoco> mapperToPoco;

        protected VirtualMapping<TPoco, TEntity> mapperToEntity;

        public ApiBaseController()
        {
            if (DbContextHelper<TContext>.GetActiveContext() == null)
                DbContextHelper<TContext>.CreateContext();

            this.Repository = new GenericRepository<TContext, TEntity>();
            this.mapperToPoco = new VirtualMapping<TEntity, TPoco>();
            this.mapperToEntity = new VirtualMapping<TPoco, TEntity>();
        }

        protected override void Dispose(bool disposing)
        {
            DbContextHelper<TContext>.DisposeContext();
            RepositoryFacade.Dispose();
            this.mapperToPoco.Dispose();
            this.mapperToEntity.Dispose();
            base.Dispose(disposing);
        }

        protected HttpResponseMessage Ok(TEntity entidade)
        {
            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        protected HttpResponseMessage Ok(IEnumerable<TEntity> entidade)
        {
            return Request.CreateResponse(HttpStatusCode.OK, entidade);
        }

        protected HttpResponseMessage Ok(TPoco poco)
        {
            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        protected HttpResponseMessage Ok(IEnumerable<TPoco> poco)
        {
            return Request.CreateResponse(HttpStatusCode.OK, poco);
        }

        protected HttpResponseMessage NotFound()
        {
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        protected HttpResponseMessage BadRequest()
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        protected TPoco MapperEntityToPoco(TEntity entidade)
        {
            return this.mapperToPoco.Map(entidade);
        }

        protected IList<TPoco> MapperEntityToPoco(IList<TEntity> entidades)
        {
            return this.mapperToPoco.Map(entidades);
        }

        protected TEntity MapperPocoToEntity(TPoco entidade)
        {
            return this.mapperToEntity.Map(entidade);
        }

        protected IList<TEntity> MapperPocoToEntity(IList<TPoco> entidades)
        {
            return this.mapperToEntity.Map(entidades);
        }
    }
}
