var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints
app.MapGet("/", () => "Olá, mundo!");

app.MapGet("frases", async() =>
            await new HttpClient().GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes") );

app.Run();
