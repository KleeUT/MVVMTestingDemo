namespace MVVM.LocationRecorder.Recording
{
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Messages;

    [Export(typeof(InteractionRecorderCommandSender))]
    public class InteractionRecorderCommandSender
    {
        private readonly IEventAggregator eventAggregator;
        
        [ImportingConstructor]
        public InteractionRecorderCommandSender(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
        }

        public void SendRecordInteractionCommand(string firstName, string lastName, double longitude, double latitude)
        {
            var person = new Person(firstName, lastName);
            var location = new Location(longitude, latitude);
            eventAggregator.PublishOnBackgroundThread(new RecordInteraction(new Interaction(person, location)));
        }
    }
}
