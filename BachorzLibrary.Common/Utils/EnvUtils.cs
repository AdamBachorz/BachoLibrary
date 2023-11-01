using System;
using System.Threading.Tasks;

namespace BachorzLibrary.Common.Utils
{
    public static class EnvUtils
    {
        public static void PerformDependingOnEnvironment(Action onDev, Action onProd)
        {
#if DEBUG
            onDev();
#else
            onProd();
#endif
        }
        
        public static async Task PerformDependingOnEnvironmentAsync(Func<Task> onDev, Func<Task> onProd)
        {
#if DEBUG
            await onDev();
#else
            await onProd();
#endif
        }
        
        public static V GetValueDependingOnEnvironment<V>(V devValue, V prodValue)
        {
#if DEBUG
            return devValue;
#else
            return prodValue;
#endif
        }
    }
}
