using System;
using System.Collections.Generic;

namespace Arquitetura.Mapeamento
{
    public interface IGenericMapping<TSource, TDestiny> : IDisposable
    {
        IList<TDestiny> Map(IList<TSource> source);

        TDestiny Map(TSource source);
    }
}
