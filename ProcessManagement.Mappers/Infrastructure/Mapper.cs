using AutoMapper;

namespace ProcessManagement.Mappers.Infrastructure
{
    internal class Mapper
    {
        public static IMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapperConfiguration(MappingConfiguration.Configure)
                                   .CreateMapper();
                }
                return instance;
            }
        }

        private static IMapper instance;
    }
}
