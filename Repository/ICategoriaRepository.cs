using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategoriasPaginas(CategoriasParameters categoriasParameters);
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    }
}