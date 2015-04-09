using Infrastructure.CommandHandlers;
using PayrollApp.AppServices;
using PayrollApp.Domain.Model;
using PayrollApp.Domain.Services;
using PayrollApp.EventHandlers;
using PayrollApp.Infrastructure.DomainServices;
using PayrollApp.Infrastructure.IoC;
using PayrollApp.Infrastructure.MessageBus;
using Rebus;
using Rebus.StructureMap;
using StructureMap;
using StructureMap.Graph;

namespace PayrollApp.Infrastructure.Configuration
{
    public class DependencyRegistry
    {
        public static void Initialize()
        {
            ObjectFactory.Configure(GlobalRegister);
        }

        private static void GlobalRegister(ConfigurationExpression i)
        {
            i.Scan(x =>
            {
                x.TheCallingAssembly(); //Server
                x.AssemblyContainingType<Employee>(); // Domain
                x.AssemblyContainingType<IGeneratePayrollAppService>(); // AppServices
                x.AssemblyContainingType<MemberAddedToOrganizationEventHandler>(); //EventHandlers
                x.AssemblyContainingType<DomainEventsPublisher>(); //DomainEvents Impl

                x.AddAllTypesOf<ICommandHandler>();

                x.WithDefaultConventions();

                //x.IncludeNamespaceContainingType<PayrollGeneratedEventHandler>();
                x.ConnectImplementationsToTypesClosing(typeof(IHandleMessages<>));
            });

            i.For<IDependencyProvider>().Singleton().Use(DependencyProvider.Instance);

            //Message Publisher
            var containerAdapter = new StructureMapContainerAdapter(ObjectFactory.Container);
            var messageBus = new MessageBus.MessageBus(containerAdapter);
            var messagePublisher = new MessagePublisher(messageBus);
            i.For<IMessagePublisher>().Singleton().Use(x => messagePublisher);

            //Domain Events Publisher
            i.For<IDomainEventsPublisher>().Singleton().Use(x => new DomainEventsPublisher(messagePublisher));
        }
    }
}