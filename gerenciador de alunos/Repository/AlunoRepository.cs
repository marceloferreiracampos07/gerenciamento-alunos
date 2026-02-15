using gerenciador_de_alunos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gerenciador_de_alunos.Repository
{
    public class AlunoRepository
    {
        private static List<Aluno> _alunos = new List<Aluno>();

        public void CadastrarAluno(Aluno aluno)
        {
            _alunos.Add(aluno);
        }


        public List<Aluno> ListarAlunos()
        {
            return _alunos;
        }


        public Aluno? Buscarporid(int id)
        {

            return _alunos.FirstOrDefault(u => u.Id == id);
        }
        public void atualizarAluno(int id, Aluno novo)
        {
            var Aluno_original = Buscarporid(id);
            if (Aluno_original != null)
            {

                Aluno_original.Nome = novo.Nome;
                Aluno_original.Email = novo.Email;

                Console.WriteLine("Usuário atualizado com sucesso!");
            }
            else
            {

                throw new Exception($"Erro: Usuário com ID {id} não foi encontrado.");
            }
        }

        public void DeletarAluno(int id)
        {
            var alunoParaRemover = Buscarporid(id);

            if (alunoParaRemover != null)
            {
                _alunos.Remove(alunoParaRemover);
                Console.WriteLine($"Aluno deletado com sucesso ");
            }
            else
            {
                throw new Exception($"erro nao foi possivel encontrar Aluno com id {id}");
            }

        }
    }
}
