using APICatalogo.Context;
using APICatalogo.Filtes;
using APICatalogo.Models;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public ProdutosController(IUnitOfWork context)
        {
            _uof = context;
        }

        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public ActionResult<IEnumerable<Produto>> Get()
        {
                var produtos = _uof.ProdutoRepository.Get().ToList();
                return produtos == null ? NotFound("Produtos não encontrados") : produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
                var produto = _uof.ProdutoRepository.GetById(p => p.ProdutoId == id);
                return produto == null ? NotFound($"Produto de id {id} não encontrado") : produto;
        }

        [HttpGet("menorpreco")]
        public ActionResult<IEnumerable<Produto>> GetProdutosPrecos()
        {
            return _uof.ProdutoRepository.GetProdutosPorPreco().ToList();
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
                _uof.ProdutoRepository.Add(produto);
                _uof.Commit();
                return new CreatedAtRouteResult("ObterProduto",
                        new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto)
        {
                if (id != produto.ProdutoId) return BadRequest();

                _uof.ProdutoRepository.Update(produto);
                _uof.Commit();

                return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
                var produto = _uof.ProdutoRepository?.GetById(p => p.ProdutoId == id);

                if (produto is null)
                {
                    return NotFound("Produto de id {id} não encontrado");
                }

                _uof.ProdutoRepository?.Delete(produto);
                _uof.Commit();

                return Ok(produto);
        }
    }
}
