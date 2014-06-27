namespace MVVM.LocationRecorder.Messages
{
    using MVVM.LocationRecorder.Data;

    public class InteractionRecorded
    {
        private readonly Interaction interaction;

        public InteractionRecorded(Interaction interaction)
        {
            this.interaction = interaction;
        }

        public Interaction Interaction
        {
            get
            {
                return interaction;
            }
        }
    }
}
