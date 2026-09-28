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
      catch(Exception e)
      {
        var erro = new ErroDto($"{e.Message}");
        Console.WriteLine(erro.Erro);
        context.Response.StatusCode = 500; // WARN: Meio implicito nao?
        await context.Response.WriteAsJsonAsync(erro); // NOTE: Bora ve se funfa...
      }
    }
}

// WARN: Temporario, ate encontrar outra possivel melhor forma de
// fazer isto
record ErroDto(string Erro){}

public static class ErroMiddlewareExtensions
{
  public static IApplicationBuilder UseErroMiddleware(
      this IApplicationBuilder builder)
  {
    return builder.UseMiddleware<ErroMiddleware>();
  }
}
