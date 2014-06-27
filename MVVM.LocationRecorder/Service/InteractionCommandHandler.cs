namespace MVVM.LocationRecorder.Service
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Messages;

    [Export(typeof(InteractionCommandHandler))]
    public class InteractionCommandHandler : IHandle<RecordInteraction>
    {
        private readonly IInteractionRecorderService service;

        [ImportingConstructor]
        public InteractionCommandHandler(IEventAggregator eventAggregator, IInteractionRecorderService service)
        {
            eventAggregator.Subscribe(this);
            this.service = service;
        }

        public void Handle(RecordInteraction message)
        {
            service.SaveInteraction(message.Interaction);
        }
    }
}
