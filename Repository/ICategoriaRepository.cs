using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        PagedList<Categoria> GetCategoriasPaginas(CategoriasParameters categoriasParameters);
         IEnumerable<Categoria> GetCategoriasProdutos();
    }
}