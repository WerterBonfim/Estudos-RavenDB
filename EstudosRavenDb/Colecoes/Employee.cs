using System;
using System.Collections.Generic;

namespace EstudosRavenDb.Colecoes
{
    internal class Employee
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public Address Address { get; set; }
        public DateTimeOffset HiredAt { get; set; }
        public DateTimeOffset Birthday { get; set; }
        public string HomePhone { get; set; }
        public long Extension { get; set; }
        public string ReportsTo { get; set; }
        public List<string> Notes { get; set; }
        public List<long> Territories { get; set; }

        public override string ToString()
        {
            return $"Employee {Id} - {FirstName} {LastName}";
        }
    }
}