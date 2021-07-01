using AutoMapper;
using ProcessManagement.Mappers.Profiles;
using System;

namespace ProcessManagement.Mappers.Infrastructure
{
    internal static class MappingConfiguration
    {
        public static Action<IMapperConfigurationExpression> Configure = (cfg) =>
        {
            cfg.AddProfile(new UserProfile());
            cfg.AddProfile(new ProjectProfile());
        };
    }
}
