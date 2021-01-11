namespace EstudosRavenDb.Colecoes
{
    internal class Produto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Supplier { get; set; }
        public string Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public long PricePerUnit { get; set; }
        public long UnitsInStock { get; set; }
        public long UnitsOnOrder { get; set; }
        public bool Discontinued { get; set; }
        public long ReorderLevel { get; set; }

        public override string ToString()
        {
            return $"{Name},  ";
        }
    }
}