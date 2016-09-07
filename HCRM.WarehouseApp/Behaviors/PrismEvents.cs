using Prism.Events;
namespace HCRM.WarehouseApp.Behaviors
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
