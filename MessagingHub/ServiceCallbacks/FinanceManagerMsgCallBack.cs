using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MessagingHub.ServiceCallbacks
{
    //[CallbackBehavior(UseSynchronizationContext = false)]
    //public class FinanceManagerMsgCallBack : IPublisherCallback
    //{
    //    private PublisherClient _msgPublisherProxy;
    //    public FinanceManagerMsgCallBack()
    //    {
    //        InstanceContext instanceContext = new InstanceContext(this);
    //        _msgPublisherProxy = new PublisherClient(instanceContext);
            
    //    }
    //    public void MessageHandler(MessageWrapper messageWrapper)
    //    {
            
    //    }

    //    public void SubscribeToAllMsgTypes()
    //    {
    //        //var allMsgTypes = typeof(ICommand).Assembly.GetExportedTypes().Where(t => t.IsClass);
    //        //foreach(var type in allMsgTypes)
    //        //{
    //        //    _msgPublisherProxy.Subscribe(type.ToString());
    //        //}
    //    }
    //}
}
