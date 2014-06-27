namespace MVVM.LocationRecorder.Recording
{
    using Caliburn.Micro;

    public class InteractionRecorderViewModel : Screen
    {
        private readonly InteractionRecorderModel model;
        private readonly InteractionRecorderCommandSender commandSender;

        public InteractionRecorderViewModel(InteractionRecorderModel model, InteractionRecorderCommandSender commandSender)
        {
            this.model = model;
            this.commandSender = commandSender;
        }

        public string FirstName
        {
            get
            {
                return model.FirstName;
            }

            set
            {
                model.FirstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }

        public string LastName
        {
            get
            {
                return model.LastName;
            }

            set
            {
                model.LastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }

        public double Longitude
        {
            get
            {
                return model.Longitude;
            }
            
            set
            {
                model.Longitude = value;
                NotifyOfPropertyChange(() => Longitude);
            }
        }

        public double Latitude
        {
            get
            {
                return model.Latitude;
            }

            set
            {
                model.Latitude = value;
                NotifyOfPropertyChange(() => Latitude);
            }
        }

        public void Save()
        {
            commandSender.SendRecordInteractionCommand(model.FirstName, model.LastName, model.Longitude, model.Latitude);
            ClearValues();
        }

        private void ClearValues()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Longitude = 0;
            Latitude = 0;
        }
    }
}
