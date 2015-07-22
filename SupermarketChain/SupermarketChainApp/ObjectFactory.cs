using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace SupermarketChainApp
{
    public static class ObjectFactory
    {
        private static IKernel kernel;

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        public static void InitializeKernel(IKernel appKernel)
        {
            kernel = appKernel;
        }
    }
}
