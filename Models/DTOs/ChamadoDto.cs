using DeskFlow.Models.Entities;

namespace DeskFlow.Models.DTOs;

public record ChamadoDto(
	  string Titulo,
	  string Descricao,
	  string SolicitanteNome,
    ChamadoPrioridade Prioridade,
    int CategoriaId
    // public DateTime DataAbertura { get; set; }
    ) {}
