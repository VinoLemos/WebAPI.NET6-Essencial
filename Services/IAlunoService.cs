using AlunosApi.Models;

namespace WebAPI.NET6_Essencial.Services
{
    public interface IAlunoService
    {
         Task<IEnumerable<Aluno>> GetAlunos();
         Task<Aluno> GetAluno(int id);
         Task<IEnumerable<Aluno>> GetAlunoByNome(string nome);
         Task CreateAluno(Aluno aluno);
         Task UpdateAluno(Aluno aluno);
         Task DeleteAluno(Aluno aluno);
    }
}