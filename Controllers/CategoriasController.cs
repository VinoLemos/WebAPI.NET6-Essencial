using APICatalogo.Context;
using APICatalogo.DTOs;
using APICatalogo.Models;
using APICatalogo.Pagination;
using APICatalogo.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace APICatalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly ILogger _logger;

        private readonly IMapper _mapper;
        public CategoriasController(IUnitOfWork context, ILogger<CategoriasController> logger, IMapper mapper)
        {
            _uof = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get([FromQuery] CategoriasParameters categoriasParameters)
        {
            _logger.LogInformation($" ======== GET api/categorias/produtos ========");
            try
            {
                var categorias = await _uof.CategoriaRepository.GetCategoriasPaginas(categoriasParameters);

                var metadata = new
                {
                    categorias.TotalCount,
                    categorias.PageSize,
                    categorias.CurrentPage,
                    categorias.TotalPages,
                    categorias.HasNext,
                    categorias.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var categoriasDTO = _mapper.Map<List<CategoriaDTO>>(categorias);
                return categoriasDTO == null ? NotFound("Categorias não encontradas") : categoriasDTO;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            _logger.LogInformation($" ======== GET api/categorias/id = {id} ========");
            try
            {
                var categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);
                var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);
                return categoriaDto == null ? NotFound($"Categoria de id {id} não encontrada") : categoriaDto;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Ocorreu um erro ao tratar sua solicitação");
            }
        }

        [HttpGet("produtos")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProdutos()
        {
            var categorias = await _uof.CategoriaRepository.GetCategoriasProdutos();
            var categoriasDto = _mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDto;
            //return _uof.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]CategoriaDTO categoriaDto)
        {
                var categoria = _mapper.Map<Categoria>(categoriaDto);
                if (categoria is null) return BadRequest();

                _uof.CategoriaRepository.Add(categoria);
                 await _uof.Commit();

                var categoriaDTO = _mapper.Map<CategoriaDTO>(categoria);
                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CategoriaDTO categoriaDto)
        {
                if (id != categoriaDto.CategoriaId) return BadRequest($"Categoria de id {id} não encontrada");

                var categoria = _mapper.Map<Categoria>(categoriaDto);

                _uof.CategoriaRepository.Update(categoria);
                await _uof.Commit();

                return Ok(categoria);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _uof.CategoriaRepository.GetById(c => c.CategoriaId == id);

                if (categoria is null) return NotFound($"Categoria de id {id} não encontrada");

                _uof.CategoriaRepository.Delete(categoria);
                await _uof.Commit();

                var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

                return Ok(categoria);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tratar sua solicitação");
            }
        }
    }
}
