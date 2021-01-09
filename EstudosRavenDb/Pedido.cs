using System;
using System.Collections.Generic;

namespace EstudosRavenDb
{
    public class Pedido
    {
        public string Company { get; set; }
        public string Employee { get; set; }
        public double Freight { get; set; }
        public List<Line> Lines { get; set; }
        public DateTimeOffset OrderedAt { get; set; }
        public DateTimeOffset RequireAt { get; set; }
        public ShipTo ShipTo { get; set; }
        public string ShipVia { get; set; }
        public object ShippedAt { get; set; }
    }
    
    public class Line
    {
        public double Discount { get; set; }
        public double PricePerUnit { get; set; }
        public string Product { get; set; }
        public string ProductName { get; set; }
        public long Quantity { get; set; }
    }
    

    public class ShipTo
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public Location Location { get; set; }
        public long PostalCode { get; set; }
        public string Region { get; set; }
    }

    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}