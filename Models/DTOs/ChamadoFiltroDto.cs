using DeskFlow.Models.Entities;

namespace DeskFlow.Models.DTOs;

public record ChamadoFiltroDto(ChamadoStatus? Status, ChamadoPrioridade? Prioridade, int? CategoriaId) {}
