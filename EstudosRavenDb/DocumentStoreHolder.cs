using System;
using Raven.Client.Documents;


namespace EstudosRavenDb
{
    public static class DocumentStoreHolder
    {
        private static readonly Lazy<IDocumentStore> LazyStore =
            new Lazy<IDocumentStore>(() =>
            {
                
                
                Console.WriteLine("DocumentStore foi inicializado");
                var store = new DocumentStore
                {
                    Urls = new[] {"http://localhost:8080"},
                    Database = "estudos"
                };

                return store.Initialize();
            });

        public static IDocumentStore Store => LazyStore.Value;
    }
}