using System;
using ZenStates.Core;

namespace ZenStates
{
    internal sealed class CpuSingleton : IDisposable
    {
        private static Cpu instance = null;
        private CpuSingleton() { }

        public static Cpu Instance
        {
            get
            {
                if (instance == null)
                    instance = new Cpu();

                return instance;
            }
        }

        public void Dispose()
        {
            ((IDisposable)instance).Dispose();
        }

        ~CpuSingleton()
        {
            Dispose();
        }
    }
}
