using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TarefasDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Endpoints
app.MapGet("/tarefas", async (AppDbContext db)=> await db.Tarefas.ToListAsync());
app.MapPost("/tarefas", async (Tarefa tarefa, AppDbContext db) => 
            {
                db.Tarefas.Add(tarefa);
                await db.SaveChangesAsync();
                return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
            });

app.Run();

class Tarefa
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public bool IsConcluida { get; set; }
}

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {}

    public DbSet<Tarefa> Tarefas => Set<Tarefa>();
}
