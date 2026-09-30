namespace DeskFlow.Models.DTOs;

public record ChamadoDto(
	  string Titulo,
	  string Descricao,
	  string SolicitanteNome,
    int CategoriaId
    // public DateTime DataAbertura { get; set; }
    ) {}
