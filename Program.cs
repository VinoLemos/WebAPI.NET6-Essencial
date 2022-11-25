using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ContatosDB"));

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
app.MapGet("/contatos", async (AppDbContext db) => await db.Contatos.ToListAsync());

app.MapGet("/contatos/{id}", async (AppDbContext db, int id) =>
            await db.Contatos.FindAsync(id) is Contato contato ?
            Results.Ok(contato) : Results.NotFound("Contato não encontrado!"));

app.MapGet("/contatos/email/{email}", async (AppDbContext db, string email) =>
            await db.Contatos.Where(c => c.Email == email).ToListAsync());

app.MapGet("/contatos/nome/{nome}", async (AppDbContext db, string nome) =>
            await db.Contatos.Where(c => c.Nome == nome).ToListAsync());

app.MapPost("/contatos", async ([FromBody]Contato contato, AppDbContext db) =>
            {
                db.Contatos.Add(contato);
                await db.SaveChangesAsync();
                return Results.Created($"/contatos/{contato.Id}", contato);
            });
app.MapPut("/contatos/{id}", async (int id, [FromBody]Contato novoContato, AppDbContext db) =>
            {
                var contato = await db.Contatos.FindAsync(id);

                if (contato is null) return Results.NotFound("Contato não encontrado!");

                contato.Nome = novoContato.Nome;
                contato.Email = novoContato.Email;
                contato.Celular = novoContato.Celular;
                contato.Github = novoContato.Github;
                contato.Linkedin = novoContato.Linkedin;

                await db.SaveChangesAsync();
                return Results.Ok(contato);
            });

app.MapDelete("/contatos/{id}", async (int id, AppDbContext db) =>
                {
                    if (await db.Contatos.FindAsync(id) is Contato contato)
                    {
                        db.Contatos.Remove(contato);
                        await db.SaveChangesAsync();
                        return Results.Ok(contato);
                    }
                    return Results.NotFound("Contato não encontrado!");
                });

app.Run();

class Contato
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Github { get; set; }
    public string? Linkedin { get; set; }
    public int Celular { get; set; }
}

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Contato> Contatos => Set<Contato>();
}
