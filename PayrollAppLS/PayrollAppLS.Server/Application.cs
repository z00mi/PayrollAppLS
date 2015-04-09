using PayrollApp.Infrastructure.Configuration;

namespace LightSwitchApplication
{
    public partial class Application
    {
        private static bool _alreadyInitialized;
        private readonly object _lockObj = new object();

        partial void Application_Initialize()
        {
            lock (_lockObj)
            {
                if (_alreadyInitialized) return;
                _alreadyInitialized = true;

                DependencyRegistry.Initialize();
                SingletonInstances.Initialize();
            }
        }
    }
}