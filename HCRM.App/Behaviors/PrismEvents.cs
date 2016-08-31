using Prism.Events;
namespace HCRM.App.Behaviors
{
    public class ItemListChanged<T> : PubSubEvent<T>
    {
    }
    public class PrintReceiptEvent<T> : PubSubEvent<T>
    {
    }

    public class SaveReceiptDeliveryResultEvent : PubSubEvent<bool>
    {
    }
}
