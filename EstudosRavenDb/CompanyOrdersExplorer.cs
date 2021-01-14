using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using EstudosRavenDb.Colecoes;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace EstudosRavenDb
{
    public class CompanyOrdersExplorer
    {
        private int _idDigitado;

        public void Start()
        {
            while (UsuarioQuerContinuar())
            {
                MostrarPedidosDaCompanhia();
            }

            Console.WriteLine("Tchau!!");
        }


        private bool UsuarioQuerContinuar()
        {
            var texto = "Digite o ID da companhia (0 para sair): ";
            _idDigitado = Utils.PedirNumeroParaUsuario(texto);

            if (_idDigitado == 0)
                return false;

            return true;
        }

        private void MostrarPedidosDaCompanhia()
        {
            var referenciaDaCompanhia = $"companies/{_idDigitado}-A";

            using var session = DocumentStoreHolder.Store.OpenSession();

            var pedidos = BuscarViaRQL(session, referenciaDaCompanhia);
            //var pedidos = BuscaViaLinq(session, referenciaDaCompanhia);

            var companhia = session.Load<Company>(referenciaDaCompanhia);
            if (companhia == null)
            {
                Console.WriteLine("Companhia não encontrada");
                return;
            }

            Console.WriteLine($"Pedido para {companhia.Name}");

            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"\t{pedido.Id} - {pedido.OrderedAt}");
                
            }
        }

        private static List<Order> BuscaViaLinq(IDocumentSession session, string referenciaDaCompanhia)
        {
            var pedidos = (
                from pedido in session.Query<Order>()
                    .Include(p => p.Company)
                where pedido.Company == referenciaDaCompanhia
                select pedido
            ).ToList();
            return pedidos;
        }

        private static List<Order> BuscarViaRQL(IDocumentSession session, string referenciaDaCompanhia)
        {
            var query =
                $"from Orders " +
                $"where Company == $companyId " +
                $"include Company";

            var pedidos = session.Advanced
                .RawQuery<Order>(query)
                .AddParameter("companyId", referenciaDaCompanhia)
                .ToList();
            return pedidos;
        }
    }
}