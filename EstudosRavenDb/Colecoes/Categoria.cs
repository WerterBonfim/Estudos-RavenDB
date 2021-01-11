namespace EstudosRavenDb.Colecoes
{
    public class Categoria
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} {Description}";
        }
    }
}