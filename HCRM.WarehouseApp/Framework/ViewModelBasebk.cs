namespace HCRM.WarehouseApp.Framework
{
    public class ViewModelBasebk<ViewType> : ObjectBase
    where ViewType : ViewInterfaces.IView
    {
        public virtual string Title
        {
            get { return string.Empty; }
        }

        private readonly ViewType view;

        public ViewType View
        {
            get
            {
                return view;
            }
        }
        public ViewModelBasebk(ViewType view)
        {
            this.view = view;
            View.DataContext = this;
        }        
    }
}
