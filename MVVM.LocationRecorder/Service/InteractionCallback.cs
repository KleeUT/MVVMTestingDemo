namespace MVVM.LocationRecorder.Service
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Messages;

    [Export(typeof(IInteractionCallback))]
    public class InteractionCallback : IInteractionCallback
    {
        readonly IEventAggregator eventAggregator;

        [ImportingConstructor]
        public InteractionCallback(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void NewInteractionRecorded(Interaction interaction)
        {
            eventAggregator.PublishOnCurrentThread(new InteractionRecorded(interaction));
        }
    }
}