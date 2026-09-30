using DeskFlow.Models.Entities;

public record ChamadoFiltroDto(string? Titulo, string? Descricao, ChamadoStatus? Status, string? SolicitanteNome, DateTime? DataAbertura, DateTime? DataFechamento) {}
// WARN: Reduzir o nome deste Dto
