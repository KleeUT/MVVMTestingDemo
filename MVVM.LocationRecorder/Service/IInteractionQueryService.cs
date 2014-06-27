namespace MVVM.LocationRecorder.Service
{
    using System.Collections.Generic;

    using MVVM.LocationRecorder.Data;

    public interface IInteractionQueryService
    {
        IEnumerable<Interaction> AllInteractions();
    }
}
