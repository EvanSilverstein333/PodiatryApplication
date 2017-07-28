using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using System.ServiceModel;
using Infrastructure.Services.PatientManagerServices.PublisherService;
using Controllers.Code.ExternalEventHandlers;
using PatientManager.Contract.Events;
using System.Diagnostics;

namespace Infrastructure.Configuration.Services
{
    //[CallbackBehavior(UseSynchronizationContext = false)]
    public class PatientManagerMessageCallback : IPublisherCallback
    {
        private static InstanceContext _context;
        
        public PatientManagerMessageCallback()
        {
            _context = new InstanceContext(this);
        }


        public static void SubscribeToMessages()
        {

            var publisher = new PublisherClient(_context);
            var time = new TimeSpan(0, 3, 0);
            publisher.Endpoint.Binding.CloseTimeout = time;
            publisher.Endpoint.Binding.OpenTimeout = time;
            publisher.Endpoint.Binding.ReceiveTimeout = time;
            publisher.Endpoint.Binding.SendTimeout = time;

            var types = GetEventTypes();
            foreach (var type in types)
            {
                publisher.Subscribe(type.ToString());
            }


        }


        private static Type[] GetEventTypes()
        {
            var types = typeof(IExternalEventHandler<>).Assembly.GetExportedTypes();
            var exHandlerTypes = types
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExternalEventHandler<>)))
                .Select(t => new {ServiceType = t.GetInterfaces().Single(), Implementation = t });


            List<Type> messageTypes = new List<Type>();
            foreach (var reg in exHandlerTypes)
            {
                var msgType = reg.ServiceType.GetGenericArguments()[0];
                if(msgType.Assembly == typeof(IDomainEvent).Assembly) // can be any type from the contract assembly of given bounded context
                {
                    if (!messageTypes.Contains(msgType)) { messageTypes.Add(msgType); }
                }
            }
            return messageTypes.ToArray();

        }

        public void MessageHandler(MessageWrapper messageWrapper)
        {

            //try
            //{
                var eventType = messageWrapper.Message.GetType();
                var handlerType = typeof(IExternalEventHandler<>).MakeGenericType(eventType);
                var handlers = Bootstrapper.Container.GetAllInstances(handlerType);
                foreach (dynamic handler in handlers)
                {
                    handler.Handle(messageWrapper.Message);
                }

            //}
            //catch(Exception e) // temp
            //{
            //    Debugger.Break(); 
            //}





        }
    }
}
