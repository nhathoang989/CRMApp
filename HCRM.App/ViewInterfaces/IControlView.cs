namespace HCRM.App.ViewInterfaces
{
    interface IControlView : IView
    {
        string Title { get; }
        string Key { get; }
    }
}
