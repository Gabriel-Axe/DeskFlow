using DeskFlow.Models.Entities;

namespace DeskFlow.Models.DTOs;

public record ChamadoDetalhesDto(
	  string Titulo,
	  string Descricao,
	  string SolicitanteNome,
    DateTime DataAbertura,
    string Prioridade,
    string Status,
    int CategoriaId,
    CategoriaDto Categoria,
    List<Interacao> Interacoes
    ) {}
