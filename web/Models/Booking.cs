using System.Collections.Generic;
using System.Device.Location;
using NodaTime;

namespace web.Models
{
    public class Booking : Entity
    {
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<Provider> Providers { get; set; }
        public IEnumerable<Consumer> Consumers { get; set; }
        public Event Event { get; set; }
        public bool Deleted { get; set; }
    }

    public abstract class Entity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Location : Entity
    {
        public IEnumerable<string> KeyHolders { get; set; }
        public IEnumerable<string> Contacts { get; set; }
        public bool Outdoor { get; set; }
        public bool PublicAccess { get; set; }
        public string Room { get; set; }
        public string Floor { get; set; }
        public GeoCoordinate GeoCoordinate { get; set; }
        public Address Address { get; set; }
    }

    public class Address : Entity
    {
        public IEnumerable<string> Lines { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }

    public class Provider : Entity
    {
    }

    public class Consumer : Entity
    {
    }

    public class Event : Entity
    {
        public string Url { get; set; }

        public string Description { get; set; }

        public LocalTime Start { get; set; }

        public LocalTime End { get; set; }
    }
}