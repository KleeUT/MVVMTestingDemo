namespace MVVM.LocationRecorder.Data
{
    using System;
    using System.Text;

    public class Location
    {
        public Location(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(LatitudeInDegreesMinutesSeconds());
            builder.Append(" ");
            builder.Append(LongitudeInDegreesMinutesSeconds());
            return builder.ToString();
        }

        public string LatitudeInDegreesMinutesSeconds()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(ToDegreesMinutesSeconds(Latitude));
            builder.Append(" ");
            builder.Append(Latitude > 0 ? "N" : "S");
            return builder.ToString();
        }

        public string LongitudeInDegreesMinutesSeconds()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(ToDegreesMinutesSeconds(Longitude));
            builder.Append(" ");
            builder.Append(Longitude > 0 ? "E" : "W");
            return builder.ToString();
        }

        private static string ToDegreesMinutesSeconds(double value)
        {
            value = Math.Abs(value);
            var degrees = (int)Math.Truncate(value);
            value = (value - degrees) * 60;
            var minutes = (int)Math.Truncate(value);
            var seconds = (value - minutes) * 60;
            seconds = Math.Round(seconds, 4);
            return string.Format("{0}° {1}\' {2}\"", degrees, minutes, seconds.ToString("0.000"));
        }

        protected bool Equals(Location other)
        {
            return Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
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
            return Equals((Location)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Longitude.GetHashCode() * 397) ^ Latitude.GetHashCode();
            }
        }
    }
}
