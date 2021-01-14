using System;
using System.Linq;
using EstudosRavenDb.Colecoes;
using Raven.Client.Documents.Session;

namespace EstudosRavenDb
{
    public class ContractsManager
    {
        public void Start()
        {
            Console.WriteLine("Werter do RavendDB - Aperte: ");

            while (MostrarMenuUI())
            {
                Console.WriteLine("");
                Console.WriteLine("");
            }


            ;
        }

        private bool MostrarMenuUI()
        {
            Console.WriteLine("C - Create");
            Console.WriteLine("R - Retrive");
            Console.WriteLine("U - Update");
            Console.WriteLine("D - Delete");
            Console.WriteLine("Q - Query all contacts (limit to 128 items)");
            Console.WriteLine("S - Stop app");

            var input = Console.ReadKey();

            Console.WriteLine("\n-------------------");

            switch (input.Key)
            {
                case ConsoleKey.S:
                    return false;

                case ConsoleKey.C:
                    CriarContato();
                    return true;

                case ConsoleKey.R:
                    ObterContato();
                    return true;

                case ConsoleKey.U:
                    AtualizarContato();
                    return true;

                case ConsoleKey.D:
                    DeletarContato();
                    return true;

                case ConsoleKey.Q:
                    MostrarTodosContatos();
                    return true;

                default:
                    return true;
            }
        }

        private void MostrarTodosContatos()
        {
            using var sessao = DocumentStoreHolder2.Store.OpenSession();

            var contatos = sessao.Query<Contato>()
                .ToList();

            Console.WriteLine($"{contatos.Count} contatos encontrados");

            foreach (var contato in contatos)
                Console.WriteLine(contato.ToString());
        }

        private void DeletarContato()
        {
            Console.WriteLine("Digite id do contato: ");
            var id = Console.ReadLine();

            using var sessao = DocumentStoreHolder2.Store.OpenSession();
            var contato = sessao.Load<Contato>(id);

            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado");
                return;
            }

            sessao.Delete(contato);
            sessao.SaveChanges();
            
        }

        private void AtualizarContato()
        {
            Console.WriteLine("Digite id do contato");

            var id = Console.ReadLine();

            using var sessao = DocumentStoreHolder2.Store.OpenSession();

            var contato = sessao.Load<Contato>(id);

            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado");
                return;
            }

            Console.WriteLine($"Nome atual: {contato.Nome}");
            Console.WriteLine("Digite o nome nome: ");
            contato.Nome = Console.ReadLine();

            Console.WriteLine($"Email atual: {contato.Email}");
            Console.WriteLine("Digite o nome email: ");
            contato.Email = Console.ReadLine();

            sessao.SaveChanges();
        }


        private void ObterContato()
        {
            Console.WriteLine("Digite id do contato: ");
            var id = Console.ReadLine();

            using var sessao = DocumentStoreHolder2.Store.OpenSession();

            var contato = sessao.Load<Contato>(id);

            if (contato == null)
            {
                Console.WriteLine("Contato não encontrado");
                return;
            }

            Console.WriteLine($"Nome: {contato.Nome}");
            Console.WriteLine($"Emamil: {contato.Email}");
        }

        private void CriarContato()
        {
            using var session = DocumentStoreHolder2.Store.OpenSession();

            Console.WriteLine("Name: ");
            var nome = Console.ReadLine();

            Console.WriteLine("Email: ");
            var email = Console.ReadLine();

            var contato = new Contato
            {
                Nome = nome,
                Email = email
            };

            session.Store(contato);

            Console.WriteLine($"Novo contato ID {contato.Id}");

            session.SaveChanges();
        }
    }
}