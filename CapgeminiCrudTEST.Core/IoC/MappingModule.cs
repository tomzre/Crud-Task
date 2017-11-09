using AutoMapper;
using CrudTT.Core.Dtos;
using CrudTT.Core.Extensions;
using CrudTT.Core.Models;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;

namespace CrudTT.Core.IoC
{
    public class MappingModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(IContext context)
        {
            Mapper.Initialize(config =>
            {

                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                config.CreateMap<Customer, CustomerDto>()
                    .ReverseMap()
                    .Ignore(x => x.Id);


                config.CreateMap<Address, AddressDto>()
                    .ReverseMap()
                    .Ignore(x => x.Id);

            });

            Mapper.AssertConfigurationIsValid();

            return Mapper.Instance;
        }
    }
}
