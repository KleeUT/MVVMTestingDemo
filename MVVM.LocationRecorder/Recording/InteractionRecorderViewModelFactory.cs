namespace MVVM.LocationRecorder.Recording
{
    using System.ComponentModel.Composition;

    [Export(typeof(InteractionRecorderViewModelFactory))]
    public class InteractionRecorderViewModelFactory 
    {
        private readonly InteractionRecorderCommandSender commandSender;
        
        [ImportingConstructor]
        public InteractionRecorderViewModelFactory(InteractionRecorderCommandSender commandSender)
        {
            this.commandSender = commandSender;
        }

        public InteractionRecorderViewModel Create()
        {
            var model = new InteractionRecorderModel();
            return new InteractionRecorderViewModel(model, commandSender);
        }
    }
}
