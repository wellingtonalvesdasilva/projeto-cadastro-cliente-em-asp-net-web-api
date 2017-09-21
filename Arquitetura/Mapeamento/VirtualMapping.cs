using ExpressMapper;
using System;

namespace Arquitetura.Mapeamento
{
    public class VirtualMapping<TSource, TDestiny> : GenericMapping<TSource, TDestiny>, IDisposable where TSource : class where TDestiny : class
    {

    }

    public class VirtualMapping<TSource, TDestiny, CustomMapper> : GenericMapping<TSource, TDestiny>, IDisposable
        where TSource : class
        where TDestiny : class
        where CustomMapper : CustomMapper<TSource, TDestiny>
    {

        protected override void RegisterAndValidate()
        {
            Mapper.RegisterCustom<TSource, TDestiny, CustomMapper>();
            Mapper.Compile();
        }
    }
}
