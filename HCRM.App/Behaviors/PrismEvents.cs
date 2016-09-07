using Prism.Events;
namespace HCRM.App.Behaviors
{
    public class ItemListChanged<T> : PubSubEvent<T>
    {
    }

    public class ItemSelected<T> : PubSubEvent<T> { }

    public class ProductListChanged : PubSubEvent<bool>
    {
    }

    public class PrintReceiptEvent<XpsDocument> : PubSubEvent<XpsDocument>
    {
    }
    public class PrintResultEvent : PubSubEvent<bool>
    {
    }

    public class ActionResultEvent : PubSubEvent<bool>
    {
    }

    public class SaveReceiptResultEvent<T> : PubSubEvent<T>
    {
    }
}
