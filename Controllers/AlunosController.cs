using AlunosApi.Models;
using Microsoft.AspNetCore.Mvc;
using WebAPI.NET6_Essencial.Services;

namespace WebAPI.NET6_Essencial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService? _alunoService;
        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService!.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao obter alunos");
            }
        }

        [HttpGet("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByNome([FromQuery] string nome)
        {
            try
            {
                var aluno = await _alunoService!.GetAlunoByNome(nome);
                return aluno.Count() == 0 ? NotFound("Aluno não existe") : Ok(aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoService!.GetAluno(id);
                return aluno == null ? NotFound($"Aluno de id {id} não existe") : Ok(aluno);
            }
            catch (System.Exception)
            {
                return BadRequest("Request inválida)");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService!.CreateAluno(aluno);
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);
            }
            catch
            {
                return BadRequest("Request inválido");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if (aluno.Id == id)
                {
                    await _alunoService!.UpdateAluno(aluno);
                    return Ok($"Aluno com id {id} atualizado com sucesso");
                }
                else return BadRequest("Request inválida");
            }
            catch
            {
                return BadRequest("Request inválida");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService!.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno removido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno de id {id} não encontrado");
                }
            }
            catch
            {
                return BadRequest("Request inválida");
            }
        }
    }
}