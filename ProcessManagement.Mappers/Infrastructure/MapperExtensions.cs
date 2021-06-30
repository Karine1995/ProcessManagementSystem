using System.Collections.Generic;
using System.Linq;

namespace ProcessManagement.Mappers.Infrastructure
{
    public static class MapperExtensions
    {
        public static TDest MapTo<TDest>(this object obj)
        {
            return Mapper.Instance.Map<TDest>(obj);
        }

        public static IEnumerable<TDest> MapTo<TDest>(this IEnumerable<object> list)
        {
            return list.Select(o => o.MapTo<TDest>());
        }
    }
}
