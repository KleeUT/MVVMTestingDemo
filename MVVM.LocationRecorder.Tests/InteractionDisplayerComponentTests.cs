namespace MVVM.LocationRecorder.Tests
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    using Caliburn.Micro;

    using Moq;

    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Displaying;
    using MVVM.LocationRecorder.Service;

    using NUnit.Framework;

    [TestFixture]
    public class InteractionDisplayerComponentTests
    {

        [Test]
        public void ViewLoadsWithCurrentState()
        {
            Given.TheQueryServiceHasValues(
                new Interaction(Obama, WhiteHouse),
                new Interaction(KleeThomas, UoN));
            And.TheTestIsSetUp();

            When.TheDisplayViewIsInitializedFromTheFactory();
            
            Then.TheDisplayDataIs(
                new Interaction(Obama, WhiteHouse),
                new Interaction(KleeThomas, UoN));
        }

        [Test]
        public void AChangeFromTheServiceIsRepresentedInTheUI()
        {
            Given.TheQueryServiceHasValues(new Interaction(Obama, WhiteHouse));
            And.TheTestIsSetUp();
            
            When.TheServiceNotifiesOfANewInteraction(new Interaction(KleeThomas, UoN));
            
            Then.TheDisplayDataIsChangedTo(
                new Interaction(Obama, WhiteHouse),
                new Interaction(KleeThomas, UoN));
        }

        private void TheDisplayDataIsChangedTo(params Interaction[] interactions)
        {
            CollectionAssert.Contains(changedProperties, "AllInteractions");
            TheDisplayDataIs(interactions);
        }

        private void TheServiceNotifiesOfANewInteraction(Interaction interaction)
        {
            callback.NewInteractionRecorded(interaction);
        }

        private void TheDisplayDataIs(params Interaction[] expectedInteractions)
        {
            CollectionAssert.AreEqual(expectedInteractions, viewModel.AllInteractions);
        }

        private void TheDisplayViewIsInitializedFromTheFactory()
        {
            viewModel = factory.Create();
        }

        private void TheQueryServiceHasValues(params Interaction[] interactions)
        {
            initialValues = interactions.ToList();
        }

        private void TheTestIsSetUp()
        {
            eventAggregator = new EventAggregator();
            
            SetUpMockQueryService();

            callback = new InteractionCallback(eventAggregator);
            factory = new InteractionDisplayViewModelFactory(mockQueryService.Object, eventAggregator);
            viewModel = factory.Create();
            changedProperties = new List<string>();
            viewModel.PropertyChanged += RecordChangedProperty;
        }

        private void RecordChangedProperty(object sender, PropertyChangedEventArgs e)
        {
            changedProperties.Add(e.PropertyName);
        }

        private void SetUpMockQueryService()
        {
            mockQueryService = new Mock<IInteractionQueryService>();
            mockQueryService.Setup(mock => mock.AllInteractions()).Returns(initialValues);
        }

        private IEventAggregator eventAggregator;
        private IInteractionCallback callback;
        private InteractionDisplayViewModelFactory factory;
        private InteractionDisplayViewModel viewModel;
        private Mock<IInteractionQueryService> mockQueryService;

        private List<string> changedProperties;

        private readonly Person KleeThomas = new Person("Klee", "Thomas");
        private readonly Person Obama = new Person("President", "Obama");
        
        private readonly Location WhiteHouse = new Location(-77.036545, 38.897096);
        private readonly Location UoN = new Location(-32.892287, 151.704210);

        

        private List<Interaction> initialValues;

        private InteractionDisplayerComponentTests Given { get { return this; } }
        private InteractionDisplayerComponentTests When { get { return this; } }
        private InteractionDisplayerComponentTests Then { get { return this; } }
        private InteractionDisplayerComponentTests And { get { return this; } }
    }
}
