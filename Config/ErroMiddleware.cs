namespace DeskFlow.Config;

// public class ErroMiddleware : IMiddleware
public class ExceptionHandlingMiddleware
{
  private RequestDelegate _next;

    // NOTE: Nao acredito que isso eh possivel...
    public ExceptionHandlingMiddleware(RequestDelegate next) => _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
      try
      {
        await _next(context);
      }
      catch(Exception e)
      {

        var cliente = new ErroDto($"Um erro aconteceu, contate o suporte");
        var desenvolvimento = new ErroDto($"Uma exceção aconteceu: {e.Message}", e.GetType().Name);

        Console.WriteLine($"ERRO: {desenvolvimento.Erro} - tipo: {desenvolvimento.Tipo}\n\nStack Trace:\n{e.StackTrace}\n\nExcecao Interna: {e.InnerException?.Message}");
        // context.Response.StatusCode = 500; // WARN: Existe uma maneira mais explicita de fazer isto?
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(cliente);
      }
    }
}

// NOTE: Nada mais permanente que uma solucao temporaria
record ErroDto(string Erro, string? Tipo = null){}
