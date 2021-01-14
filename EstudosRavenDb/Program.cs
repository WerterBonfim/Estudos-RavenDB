using System;
using System.Diagnostics;
using System.Linq;
using EstudosRavenDb.Colecoes;
using Raven.Client.Documents;

namespace EstudosRavenDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //ObtendoUmDocumento();
            //VerificaSeUmDocumentoECarregandoUmaVezEmUmaSessao();
            //CarregandoVariosDocumentos();
            //CarregarDocumentosRelacionados();
            //OrderExplorer();

            //new CompanyOrdersExplorer().Start();
            //new CrudDocuments().Start();
            new ContractsManager().Start();
        }

        private static void OrderExplorer()
        {
            while (true)
            {
                Console.WriteLine("Digite o numero da ordem # (0 para sair): ");
                
                if (EUmNumeroInvalido(out var orderNumber))
                {
                    Console.WriteLine("Ordem inválida");
                    continue;
                }
                
                if (orderNumber == 0)
                    break;

                MostrarPedido(orderNumber);
                Console.WriteLine("\n\n");
            }

            Console.WriteLine("Tchau!!");
        }

        private static bool EUmNumeroInvalido(out int orderNumber)
        {
            return !int.TryParse(Console.ReadLine(), out orderNumber);
        }

        private static void MostrarPedido(int numeroPedido)
        {
            using var session = DocumentStoreHolder.Store.OpenSession();

            var pedido = session
                .Include<Order>(x => x.Company)
                .Include(x => x.Employee)
                .Include(o => o.Lines.Select(l => l.Product))
                .Load($"orders/{numeroPedido}-A");
            
            if (pedido == null)
            {
                Console.WriteLine($"Order #{numeroPedido} not found.");
                return;
            }

            Console.WriteLine($"Numero do pedido: {numeroPedido}");

            var company = session.Load<Company>(pedido.Company);
            Console.WriteLine(company.ToString());
            
            var empregado = session.Load<Employee>(pedido.Employee);
            Console.WriteLine(empregado.ToString());

            foreach (var item in pedido.Lines)
            {
                
                var produto = session.Load<Produto>(item.Product);
                Console.WriteLine($"\t{item.ProductName}, {item.Quantity} x {produto.QuantityPerUnit}");
            }

        }

        private static void CarregarDocumentosRelacionados()
        {
            using var session = DocumentStoreHolder.Store.OpenSession();
            var produto = session
                .Include<Produto>(x => x.Category)
                .Load("products/1-A");

            var categoria = session.Load<Categoria>(produto.Category);

            Console.WriteLine(produto.ToString());
            Console.WriteLine(categoria.ToString());
        }

        private static void CarregandoVariosDocumentos()
        {
            using var session = DocumentStoreHolder.Store.OpenSession();
            var produtos = session.Load<Produto>(new[]
            {
                "products/1-A",
                "products/2-A",
                "products/3-A"
            });

            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.ToString());
            }
        }


        private static void VerificaSeUmDocumentoECarregandoUmaVezEmUmaSessao()
        {
            using var session = DocumentStoreHolder.Store.OpenSession();
            var p1 = session.Load<Produto>("products/1-A");
            var p2 = session.Load<Produto>("products/1-A");
            
            var resultado = ReferenceEquals(p1, p2);
        }

        private static void ObtendoUmDocumento()
        {
            using IDocumentStore store = new DocumentStore
            {
                Urls = new[]
                {
                    "http://localhost:8080"
                },
                Database = "estudos",
                Conventions = { }
            };
            store.Initialize();

            using var session = store.OpenSession();
            var produto = session.Load<dynamic>("product/8-A");
            Console.WriteLine(produto.FirstName);
        }
    }
}