namespace MVVM.LocationRecorder.Displaying
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Caliburn.Micro;
    using MVVM.LocationRecorder.Data;

    public class InteractionDisplayViewModel : Screen
    {
        private readonly InteractionDisplayModel model;

        public InteractionDisplayViewModel(InteractionDisplayModel model)
        {
            this.model = model;
            model.InteractionsUpdated += BackingCollectionUpdated;
        }
        
        public ObservableCollection<Interaction> AllInteractions
        {
            get
            {
                return new ObservableCollection<Interaction>(model.AllInteractions);
            }
        }

        private void BackingCollectionUpdated(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(() => AllInteractions);
        }
    }
}
