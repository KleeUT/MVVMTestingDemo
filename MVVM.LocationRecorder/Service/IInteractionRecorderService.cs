namespace MVVM.LocationRecorder.Service
{
    using MVVM.LocationRecorder.Data;

    public interface IInteractionRecorderService
    {
        void SaveInteraction(Interaction interaction);
    }
}
