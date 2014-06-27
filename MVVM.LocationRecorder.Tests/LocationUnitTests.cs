namespace MVVM.LocationRecorder.Tests
{
    using MVVM.LocationRecorder.Data;

    using NUnit.Framework;

    [TestFixture]
    public class LocationUnitTests
    {
        [Test]
        public void FormatsStringInDegreesMinutesSeconds()
        {
            var location = new Location(19.15799, 32.888655);
            Assert.AreEqual("32° 53' 19.158\" N 19° 9' 28.764\" E", location.ToString());
        }

        [Test]
        public void FormatsLatitudeInDegreesMinutesSeconds()
        {
            var location = new Location(19.15799, 32.888655);
            Assert.AreEqual("32° 53' 19.158\" N", location.LatitudeInDegreesMinutesSeconds());
        }

        [Test]
        public void FormatsLongitudeInDegreesMinutesSeconds()
        {
            var location = new Location(19.15799, 32.888655);
            Assert.AreEqual("19° 9' 28.764\" E", location.LongitudeInDegreesMinutesSeconds());
        }
    }
}
