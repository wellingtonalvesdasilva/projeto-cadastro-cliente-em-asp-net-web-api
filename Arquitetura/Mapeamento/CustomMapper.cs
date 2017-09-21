using ExpressMapper;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;

namespace Arquitetura.Mapeamento
{
    public class CustomMapper<TSource, TDestiny> : ICustomTypeMapper<TSource, TDestiny>
    {
        public TDestiny Map(IMappingContext<TSource, TDestiny> context)
        {
            return CustomMapping(context.Source);
        }

        public virtual TDestiny CustomMapping(TSource source)
        {
            return default(TDestiny);
        }

        public EntityCollection<T> ToEntityCollection<T>(IList<T> list) where T : class
        {
            var entityCollection = new EntityCollection<T>();
            list.ToList().ForEach(entityCollection.Add);
            return entityCollection;
        }
    }
}
