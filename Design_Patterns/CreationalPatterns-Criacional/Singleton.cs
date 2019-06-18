using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalPatterns_Criacional
{
    public sealed class Singleton
    {
        static Singleton Instance = new Singleton();

        protected Singleton()
        { }

        public static Singleton GetSingleton()
        {
            return Instance;
        }
    }
}
