namespace MVVM.LocationRecorder.Service
{
    using MVVM.LocationRecorder.Data;

    public interface IInteractionCallback
    {
        void NewInteractionRecorded(Interaction interaction);
    }
}
