using Prism.Events;

namespace HCRM.App.Services
{
    internal sealed class ApplicationService
    {
        private ApplicationService() { }

        private static readonly ApplicationService _instance = new ApplicationService();

        internal static ApplicationService Instance { get { return _instance; } }

        private IEventAggregator _globalEventAggregator;
        internal IEventAggregator GlobalEventAggregator
        {
            get
            {
                if (_globalEventAggregator == null)
                    _globalEventAggregator = new EventAggregator();

                return _globalEventAggregator;
            }
        }

        private IEventAggregator _activeEventAggregator;
        internal IEventAggregator ActiveEventAggregator
        {
            get
            {
                if (_activeEventAggregator == null)
                    _activeEventAggregator = new EventAggregator();

                return _activeEventAggregator;
            }
            set {
                _activeEventAggregator = value;
            }
        }
    }
}
