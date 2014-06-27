namespace MVVM.LocationRecorder.Displaying
{
    using System;
    using System.Collections.Generic;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Messages;

    public class InteractionDisplayModel : IHandle<InteractionRecorded>
    {
        private readonly List<Interaction> allInteractions;

        public event EventHandler<EventArgs> InteractionsUpdated;

        public InteractionDisplayModel(List<Interaction> allInteractions, IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
            this.allInteractions = allInteractions;
        }

        public List<Interaction> AllInteractions
        {
            get
            {
                return allInteractions;
            }
        }

        public void Handle(InteractionRecorded message)
        {
            allInteractions.Add(message.Interaction);
            if (InteractionsUpdated != null)
            {
                InteractionsUpdated.Invoke(this, EventArgs.Empty);
            }
        }
    }
}