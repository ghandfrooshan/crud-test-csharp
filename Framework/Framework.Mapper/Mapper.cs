using AutoMapper;
using Framework.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Mapper
{
    public class Mapper : Core.Mapper.IMapper
    {
        public static List<TypePair> typePairs = new List<TypePair>();

        private AutoMapper.IMapper MapperContainer;


        public TDestination Map<TDestination, TSource>(TSource source)
        {
            Config<TDestination, TSource>();

            return MapperContainer.Map<TSource, TDestination>(source);
        }


        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source)
        {
            Config<TDestination, TSource>();

            return MapperContainer.Map<IList<TSource>, IList<TDestination>>(source);
        }


        protected void Config<TDestination, TSource>(int depth = 5)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestination));

            if (typePairs.Any(a =>
                a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType))
                return;

            typePairs.Add(typePair);
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                    cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth);
                    //  cfg.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
                    cfg.ValidateInlineMaps = false;
                }
            });

            MapperContainer = config.CreateMapper();
            //MapperContainer.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
