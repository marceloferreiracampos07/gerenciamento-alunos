using gerenciador_de_alunos.Models;
using gerenciador_de_alunos.Repository;
using gerenciador_de_alunos.Utils;
using System;

namespace gerenciador_de_alunos
{
    class Program
    {
        static void Main(string[] args)
        {
            AlunoRepository repo = new AlunoRepository();
            bool rodando = true;

            while (rodando)
            {
                Console.WriteLine("\n--- GERENCIADOR DE ALUNOS ---");
                Console.Write("1-Add | 2-Lista | 3-Busca | 4-Edit | 5-Del | 0-Sair: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        if (Validacoes.ValidarNome(nome) && Validacoes.Validaremail(email))
                        {
                            repo.CadastrarAluno(new Aluno { Id = id, Nome = nome, Email = email });
                            Console.WriteLine("Sucesso!");
                        }
                        else Console.WriteLine("Dados inválidos.");
                        break;

                    case "2":
                        foreach (var a in repo.ListarAlunos())
                            Console.WriteLine($"{a.Id} - {a.Nome} ({a.Email})");
                        break;

                    case "3":
                        Console.Write("ID: ");
                        var aluno = repo.Buscarporid(int.Parse(Console.ReadLine()));
                        Console.WriteLine(aluno != null ? $"{aluno.Nome}" : "Não encontrado");
                        break;

                    case "4":
                        Console.Write("ID para editar: ");
                        int idAtu = int.Parse(Console.ReadLine());
                        Console.Write("Novo Nome: ");
                        string nNome = Console.ReadLine();
                        Console.Write("Novo Email: ");
                        string nEmail = Console.ReadLine();

                        try
                        {
                            repo.atualizarAluno(idAtu, new Aluno { Nome = nNome, Email = nEmail });
                            Console.WriteLine("Atualizado!");
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;

                    case "5":
                        Console.Write("ID para deletar: ");
                        try
                        {
                            repo.DeletarAluno(int.Parse(Console.ReadLine()));
                            Console.WriteLine("Removido!");
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                        break;

                    case "0":
                        rodando = false;
                        break;
                }
            }
        }
    }
}