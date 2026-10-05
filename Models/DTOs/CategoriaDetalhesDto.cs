using DeskFlow.Models.DTOs;

public record CategoriaDetalhesDto(int Id, string Nome, List<ChamadoListaDto> ChamadoLista){}
