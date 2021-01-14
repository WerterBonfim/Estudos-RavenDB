namespace EstudosRavenDb.Colecoes
{
    public class Contato
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Nome} - {Email}";
        }
    }
}