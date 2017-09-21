using ExpressMapper;
using System;
using System.Collections.Generic;

namespace Arquitetura.Mapeamento
{
    public abstract class GenericMapping<TSource, TDestiny> : IGenericMapping<TSource, TDestiny>, IDisposable where TSource : class where TDestiny : class
    {
        public GenericMapping()
        {
            this.RegisterAndValidate();
        }

        protected virtual void RegisterAndValidate()
        {
            Mapper.Register<TSource, TDestiny>();
            Mapper.Compile();
        }

        public IList<TDestiny> Map(IList<TSource> source)
        {
            IList<TDestiny> instancia = Activator.CreateInstance<List<TDestiny>>();
            return (IList<TDestiny>)Mapper.Map<IList<TSource>, IList<TDestiny>>(source, instancia);
        }

        public TDestiny Map(TSource source)
        {
            TDestiny instancia = Activator.CreateInstance<TDestiny>();
            return (TDestiny)Mapper.Map<TSource, TDestiny>(source, instancia);
        }

        public void Dispose()
        {
            Mapper.Reset();
        }
    }
}
