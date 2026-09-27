using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

[Table("tb_categorias")]
public class Categoria
{
  [Key]
  [Column("id")]
  public int Id { get; set; }

  [Column("nome", TypeName ="varchar(64)")]
  [Required]
  public string Nome { get; set; }

  public Categoria(int id, string nome)
  {
    Id = id;
    Nome = nome;
  }
}
