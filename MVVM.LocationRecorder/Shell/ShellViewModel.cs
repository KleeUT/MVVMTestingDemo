namespace MVVM.LocationRecorder
{
    using System;
    using System.ComponentModel.Composition;

    using Caliburn.Micro;

    using MVVM.LocationRecorder.Displaying;
    using MVVM.LocationRecorder.Recording;

    [Export(typeof(ShellViewModel))]
    public class ShellViewModel : PropertyChangedBase
    {
        private InteractionRecorderViewModel interactionRecorder;

        [ImportingConstructor]
        public ShellViewModel(InteractionRecorderViewModelFactory recorderfFactory, InteractionDisplayViewModelFactory displayViewModelFactory)
        {
            InteractionRecorder = recorderfFactory.Create();
            InteractionDisplayer = displayViewModelFactory.Create();
        }

        public InteractionDisplayViewModel InteractionDisplayer { get; set; }

        public InteractionRecorderViewModel InteractionRecorder
        {
            get
            {
                return interactionRecorder;
            }
            set
            {
                interactionRecorder = value;
                NotifyOfPropertyChange(() => InteractionRecorder);
            }
        }
    }
}
