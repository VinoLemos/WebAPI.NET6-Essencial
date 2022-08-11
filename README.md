# Web APIs ASP .NET Core - Visão Geral

## Controllers

Os controllers são arquivos armazenados dentro da pasta Controllers criada na raíz de uma aplicação ASP .NET Core Web API usando o template de projeto padrão.

Eles são o **cérebro** de uma aplicação web, processando e respondendo às requisições recebidas, executando operações nos dados recebidos por modelos de dados, e selecionam as views para ser exibidas no navegador, permitindo a interação com o usuário.

Os controladores numa web api, são classes que derivam da ControllerBase.

O nome de um controller é formado pelo nome do controlador, seguido do sufixo Controller.

Ex: CategoriasController, ProdutosController.

Estrutura básica de um controller:

```csharp
[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
	// Injeção de dependência do contexto
	private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }
	//métodos Action
	[HttpGet]
  public ActionResult<IEnumerable<Produto>> Get()
  {
      var produtos = _context.Produtos.ToList();
		  return produtos == null ? NotFound() : produtos;
		        /*
		        if(produtos is null)
		        {
		            return NotFound();
		        }
		        return produtos;
		        */
  }

	[HttpGet("{id:int}")]
  public ActionResult<Produto> Get(int id)
  {
      var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
      return produto == null ? NotFound("Produto não encontrado") : produto;
  }

	[HttpPost]
  public ActionResult Post(Produto produto)
  {
      if (produto is null)
          return BadRequest();
          
      _context.Produtos.Add(produto);
      _context.SaveChanges();
      return new CreatedAtRouteResult("ObterProduto", 
              new { id = produto.ProdutoId}, produto);
  }

	[HttpPut("{id:int}")]
  public ActionResult Put(int id, Produto produto)
  {
      if(id != produto.ProdutoId) return BadRequest();

      _context.Entry(produto).State = EntityState.Modified;
      _context.SaveChanges();

      return Ok(produto);
  }

	[HttpDelete("{id:int}")]
  public ActionResult Delete(int id)
  {
      var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);

      if (produto is null)
      {
          return NotFound("Produto não encontrado");
      }

      _context.Produtos.Remove(produto);
      _context.SaveChanges();

      return Ok(produto);
  }
}
```

<aside>
💡 O método NotFound() só funcionara com ActionResult

</aside>

<aside>
💡 Uma desvantagem dessa abordagem do método Put, é que todos os campos do Request Body tem de ser preenchidos. Então, para realizar uma atualização parcial, como apenas o nome ou categoria, usa-se o método Patch.

</aside>

<aside>
❗ Para retornar classes relacionadas em um só método Action, podemos usar o método Include.

</aside>

```tsx
[HttpGet("produtos")]
public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
{
		return _context.Categorias.Include(p => p.Produtos).ToList();
}
```

A classe ControllerBase fornece muitas propriedades e métodos que são úteis para lidar com requisições HTTP.

O Atributo ApiController permite decorar os controladores habilitando recursos como:

- Requisito de roteamento de atributo;
- Respostas HTTP 400 automáticas (Validação de Model State);
- Inferência de parâmetro de origem de associação;
- Inferência de solicitação de dados de várias partes/formulário;
- Uso de Problem Details para códigos de status de erro.

O Atributo Route especifica um padrão de URL para acessar um controller ou Action 

[Route(”[Controller]”) → Indica a rota com o nome do controlador (teste)

| Métodos | Descrição |
| --- | --- |
| BadRequest() | Retorna o status code 400 |
| NotFound() | Retorna o status code 404 |
| CreatedAtAction() | Retorna o status code 201 |
| PhysicalFile() | Retorna um arquivo |
| TryValidationModel() | Invoca a validação do modelo |
| Ok() | Retorna o status code 200 |

Para que os controladores possam ser acessados e utilizados, é preciso definir a seguinte configuração na classe Program.cs

```csharp
var builder = WebApplicatin.CreateBuiler(args);
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();
// Configure the HTTP request pipeline

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
```
