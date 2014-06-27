namespace MVVM.LocationRecorder.Messages
{
    using MVVM.LocationRecorder.Data;

    public class RecordInteraction
    {
        private readonly Interaction interaction;

        public RecordInteraction(Interaction interaction)
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
