using Autofac;

namespace Reinmar.Static
{
    public class ContainerProvider
    {
        private static IContainer container = null;

        public static IContainer Container { 
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }
    }
}
