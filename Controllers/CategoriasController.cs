using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger _logger;
        public CategoriasController(IUnitOfWork context, ILogger<CategoriasController> logger)
        {
            _uof = context;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            _logger.LogInformation($" ======== GET api/categorias/produtos ========");
            try
            {
                var categorias = _uof.CategoriaRepository.Get().ToList();
                return categorias == null ? NotFound("Categorias não encontradas") : categorias;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            _logger.LogInformation($" ======== GET api/categorias/id = {id} ========");
            try
            {
                var categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
                return categoria == null ? NotFound($"Categoria de id {id} não encontrada") : categoria;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
        {
            return _uof.CategoriaRepository.GetCategoriasProdutos().ToList();
            //return _uof.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpPost]
        public ActionResult Post(Categoria categoria)
        {
                if (categoria is null) return BadRequest();

                _uof.CategoriaRepository.Add(categoria);
                _uof.Commit();
                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Categoria categoria)
        {
                if (id != categoria.CategoriaId) return BadRequest($"Categoria de id {id} não encontrada");

                _uof.CategoriaRepository.Update(categoria);
                _uof.Commit();

                return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var categoria = _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);

                if (categoria is null) return NotFound($"Categoria de id {id} não encontrada");

                _uof.CategoriaRepository.Delete(categoria);
                _uof.Commit();

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar sua solicitação");
            }
        }
    }
}
