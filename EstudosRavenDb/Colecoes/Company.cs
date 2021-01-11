namespace EstudosRavenDb.Colecoes
{
    internal class Company
    {
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public override string ToString()
        {
            return $"Company: {Id} - {Name}";
        }
    }
    
    public class Address
    {
        public string Line1 { get; set; }
        public object Line2 { get; set; }
        public string City { get; set; }
        public object Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public Location Location { get; set; }
    }

    

    public class Contact
    {
        public string Name { get; set; }
        public string Title { get; set; }
    }

   
}