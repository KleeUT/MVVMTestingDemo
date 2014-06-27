namespace MVVM.LocationRecorder.Data
{
    public class Interaction
    {
        public Interaction(Person person, Location location)
        {
            this.Person = person;
            this.Location = location;
        }

        public Person Person { get; private set; }
        public Location Location { get; private set; }

        protected bool Equals(Interaction other)
        {
            return Equals(Person, other.Person) && Equals(Location, other.Location);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Interaction)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Person != null ? Person.GetHashCode() : 0) * 397) ^ (Location != null ? Location.GetHashCode() : 0);
            }
        }
    }
}
