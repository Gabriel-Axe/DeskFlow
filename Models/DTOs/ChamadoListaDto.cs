using DeskFlow.Models.Entities;

namespace DeskFlow.Models.DTOs;

public record ChamadoListaDto(
    int Id,
	  string Titulo,
	  string Descricao,
	  string SolicitanteNome,
    ChamadoPrioridade Prioridade,
    ChamadoStatus Status,
    int CategoriaId) {}

