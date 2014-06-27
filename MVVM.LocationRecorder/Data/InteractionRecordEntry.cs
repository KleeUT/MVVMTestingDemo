namespace MVVM.LocationRecorder.Data
{
    public class InteractionRecordEntry
    {
        private readonly Person person;

        private readonly Location location;

        public InteractionRecordEntry(Person person, Location location)
        {
            this.person = person;
            this.location = location;
        }

        public Person Person
        {
            get
            {
                return person;
            }
        }

        public Location Location
        {
            get
            {
                return location;
            }
        }
    }
}
