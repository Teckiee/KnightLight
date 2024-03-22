using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.IoC
{
    public static class Mvx
    {
        /// <summary>
        /// Returns a singleton instance of the default IoC Provider. If possible use dependency injection instead.
        /// </summary>
        public static IMvxIoCProvider? IoCProvider => MvxSingleton<IMvxIoCProvider>.Instance;
    }
}
