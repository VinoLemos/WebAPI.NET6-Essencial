<h2>Repositório com exemplo de uma API mínima</h2>
</br>
Um novo recurso do .NET 6 chamado Minimal API, permite criar APIS com o mínimo de dependência do framework Web API, o mínimo de código, e o mínimo de arquivos.

As minimal APIs usam os novos recursos do C# como Global using, e instruções de nível superior (top level statement), de forma a otimizar a experiência de inicialização do aplicati

- Não existe mais o arquivo Startup.cs;
- É usado o novo recurso implicit usings;
- É usado o novo modelo de hospedagem com WebApplication.CreateBuilder;
- As instruções de nível superior são usadas no arquivo Program.cs (sem namespace, classe ou declarações de método)
- São usados os tipos de referência anuláveis.


# Top Level Statement

Instruções de nível superior permitem que você evite usar as cerimônias extras necessárias ao posicionar o ponto de partida da sua aplicação em um método estático de uma classe. O ponto de partida típico para uma nova aplicação de console se parece com o seguinte código: 

```csharp
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

O código ao lado é o resultado do comando `dotnet new console`  que cria uma nova aplicação de console. Essas linhas de código contém apenas uma linha executável. Você pode simplificar este programa com as novas funcionalidades das instruções de nível superior

```csharp
using System;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

Mais em: 

[Top-level statements - C# tutorial](https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/top-level-statements)


