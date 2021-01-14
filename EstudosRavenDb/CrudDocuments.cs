using EstudosRavenDb.Colecoes;

namespace EstudosRavenDb
{
    public class CrudDocuments
    {
        private static string _categoriaId;

        public void Start()
        {
            Inserindo();
            Alterar();
            Deletar();
        }

        private static void Deletar()
        {
            var sessao = DocumentStoreHolder.Store.OpenSession();
            sessao.Delete(_categoriaId);
            sessao.SaveChanges();
        }

        private static void Alterar()
        {
            var sessao = DocumentStoreHolder.Store.OpenSession();
            var categoriaArmazenada = sessao.Load<Categoria>(_categoriaId);
            categoriaArmazenada.Name = "Alterado";
            sessao.SaveChanges();
        }

        private static void Inserindo()
        {
            using var sessao = DocumentStoreHolder.Store.OpenSession();

            var novaCategoria = new Categoria
            {
                Name = "Minha nova categoria",
                Description = "Descrição da nova categoria"
            };

            sessao.Store(novaCategoria);
            _categoriaId = novaCategoria.Id;
            sessao.SaveChanges();
        }
    }
}