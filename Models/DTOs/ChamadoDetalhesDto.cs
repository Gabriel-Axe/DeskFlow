using DeskFlow.Models.Entities;

namespace DeskFlow.Models.DTOs;

public record ChamadoDetalhesDto(
	  string Titulo,
	  string Descricao,
	  string SolicitanteNome,
    int CategoriaId,
    DateTime DataAbertura,
    string Prioridade,
    string Status 
    ) {}
