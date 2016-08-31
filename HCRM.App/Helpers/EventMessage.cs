using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCRM.App.Helpers
{
    public class EventMessage<T> where T: PubSubEvent<T>, new()
    {
        private static EventMessage<T> _instance;
        public static EventMessage<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventMessage<T>();
                }
                return _instance;
            }
        }
        
        public static void SendMessage(T _event, IEventAggregator _eventAggregator)
        {
            _eventAggregator.GetEvent<T>().Publish(_event);
        }
        
    }
}
