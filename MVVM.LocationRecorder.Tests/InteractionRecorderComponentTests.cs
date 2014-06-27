namespace MVVM.LocationRecorder.Tests
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Caliburn.Micro;
    using Moq;
    using MVVM.LocationRecorder.Data;
    using MVVM.LocationRecorder.Recording;
    using MVVM.LocationRecorder.Service;

    using NUnit.Framework;

    [TestFixture]
    public class InteractionRecorderComponentTests
    {
        [Test]
        public void RecordingAPersonAtALocationCommandIsSentToTheService()
        {
            SetUp();
            Given.FieldsWithData("President", "Obama", -77.036545, 38.897096);
            When.SaveIsPressed();
            Then.TheServiceIsToldToSaveIt();
        }

        [Test]
        public void SubmittingTheValuesClearsTheUI()
        {
            SetUp();
            Given.FieldsWithData("President", "Obama", -77.036545, 38.897096);
            When.SaveIsPressed();
            Then.TheUIIsCleared();
        }

        private void TheUIIsCleared()
        {
            Assert.AreEqual(String.Empty, viewModel.FirstName);
            Assert.AreEqual(String.Empty, viewModel.LastName);
            Assert.AreEqual(0, viewModel.Longitude);
            Assert.AreEqual(0, viewModel.Latitude);
            AssertPropertiesWereChanged("FirstName", "LastName", "Longitude", "Latitude");
        }

        private void AssertPropertiesWereChanged(params string[] properties)
        {
            foreach (var property in properties)
            {
                CollectionAssert.Contains(changedProperties, property);
            }
        }

        private void TheServiceIsToldToSaveIt()
        {
            mockService.Verify(mock => mock.SaveInteraction(It.Is<Interaction>(interaction => 
                interaction.Person.FirstName.Equals("President")  &&
                interaction.Person.LastName.Equals("Obama") &&
                interaction.Location.Longitude.Equals(-77.036545) &&
                interaction.Location.Latitude.Equals(38.897096))));
        }

        private void FieldsWithData(string firstName, string lastName, double longitude, double latitude)
        {
            viewModel.FirstName = firstName;
            viewModel.LastName = lastName;
            viewModel.Longitude = longitude;
            viewModel.Latitude = latitude;
        }

        private void SaveIsPressed()
        {
            viewModel.Save();
        }

        private void SetUp()
        {
            mockService = new Mock<IInteractionRecorderService>();
            
            eventAggregator = new EventAggregator();
            commandSender = new InteractionRecorderCommandSender(eventAggregator);
            var factory = new InteractionRecorderViewModelFactory(commandSender);
            viewModel = factory.Create();
            commandHandler = new InteractionCommandHandler(eventAggregator, mockService.Object);
            changedProperties = new List<string>();
            viewModel.PropertyChanged += RecordProperyChanged;
        }

        private void RecordProperyChanged(object sender, PropertyChangedEventArgs e)
        {
            changedProperties.Add(e.PropertyName);
        }

        private InteractionRecorderViewModel viewModel;
        EventAggregator eventAggregator;
        InteractionRecorderCommandSender commandSender;

        private Mock<IInteractionRecorderService> mockService;

        private InteractionCommandHandler commandHandler;

        private List<string> changedProperties;
        private InteractionRecorderComponentTests Given { get { return this; } }
        private InteractionRecorderComponentTests When { get { return this; } }
        private InteractionRecorderComponentTests Then { get { return this; } }
        private InteractionRecorderComponentTests And { get { return this; } }
        private InteractionRecorderComponentTests With { get { return this; } }
    }
}
