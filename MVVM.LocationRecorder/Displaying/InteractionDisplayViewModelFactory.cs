namespace MVVM.LocationRecorder.Displaying
{
    using System.ComponentModel.Composition;
    using System.Linq;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Service;

    [Export(typeof(InteractionDisplayViewModelFactory))]
    public class InteractionDisplayViewModelFactory
    {
        private readonly IInteractionQueryService queryService;

        private readonly IEventAggregator eventAggregator;

        [ImportingConstructor]
        public InteractionDisplayViewModelFactory(IInteractionQueryService queryService, IEventAggregator eventAggregator)
        {
            this.queryService = queryService;
            this.eventAggregator = eventAggregator;
        }

        public InteractionDisplayViewModel Create()
        {
            var model = new InteractionDisplayModel(queryService.AllInteractions().ToList(), eventAggregator);
            return new InteractionDisplayViewModel(model);
        }
    }
}
