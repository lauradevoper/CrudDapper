using Solucao_CrudDapper.Models;
using System.Collections;

namespace Solucao_CrudDapper.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<IEnumerable> CreateLivro(Livro livro);
        Task<IEnumerable> DeleteLivro(int livroid);
        Task<IEnumerable<Livro>> GetAllLivros();   
        Task<Livro> GetLivroById(int livroId);
        Task<IEnumerable> UpdateLivro(Livro livro);
                
    }
}
