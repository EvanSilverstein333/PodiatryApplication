using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using View.ViewLauncher;

namespace Infrastructure.Abstractions
{
    public class ViewLauncher : IViewLauncher
    {

        public ViewLauncher()
        {
        }

        /// <summary>
        /// Raises the given domain event
        /// </summary>
        /// <typeparam name="TLaunchableView">Domain event type</typeparam>
        /// <param name="LaunchableView">Controller event</param>
        public void Raise<TLaunchableView>(TLaunchableView LaunchableView) where TLaunchableView : class, ILaunchableView
        {
            //Get all the handlers that handle events of type T
            var handlers = Bootstrapper.Container.GetAllInstances<ILaunchableViewHandler<TLaunchableView>>();
            foreach(var handler in handlers)
            {
                handler.Handle(LaunchableView);

            }

        }
    }
}
