namespace MVVM.LocationRecorder.Storage
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Service;

    [Export(typeof(IInteractionRecorderService))]
    [Export(typeof(IInteractionQueryService))]
    public class InMemoryStorageService : IInteractionQueryService, IInteractionRecorderService
    {
        private readonly IInteractionCallback callback;

        private List<Interaction> interactions;

        [ImportingConstructor]
        public InMemoryStorageService(IInteractionCallback callback)
        {
            this.callback = callback;
            interactions = new List<Interaction>();
        }

        public void SaveInteraction(Interaction interaction)
        {
            interactions.Add(interaction);
            callback.NewInteractionRecorded(interaction);
        }

        public IEnumerable<Interaction> AllInteractions()
        {
            return interactions;
        }
    }
}