namespace DeskFlow.Config;

// public class ErroMiddleware : IMiddleware
public class ErroMiddleware
{
  private RequestDelegate _next;

    // NOTE: Nao acredito que isso eh possivel...
    public ErroMiddleware(RequestDelegate next) => _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch(InvalidOperationException e)
      {
        // WARN: Sera que eu deixo esse tipo de erro aparecendo ao cliente?
        // WARN: Vale a pena tratar todo tipo de excecao?
        // WARN: Vale aqui notar que ha espaco para colocar uma interface de logging...
        var erro = new ErroDto($"Operacao invalida: {e.Message}");
        Console.WriteLine(erro.Erro);
        context.Response.StatusCode = 500; // WARN: 500 ou 4xx?
        await context.Response.WriteAsJsonAsync(erro);
      }
      catch(Exception e)
      {
        var erro = new ErroDto($"Um erro aconteceu, contate o suporte ({e.Message})", e.GetType().Name);
        Console.WriteLine(erro.Erro);
        context.Response.StatusCode = 500; // WARN: Meio implicito nao?
        await context.Response.WriteAsJsonAsync(erro); // NOTE: Bora ve se funfa...
      }
    }
}

// WARN: Temporario, ate encontrar outra possivel melhor forma de
// fazer isto
record ErroDto(string Erro, string tipo = null){}

public static class ErroMiddlewareExtensions
{
  public static IApplicationBuilder UseErroMiddleware(
      this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<ErroMiddleware>();
  }
}
