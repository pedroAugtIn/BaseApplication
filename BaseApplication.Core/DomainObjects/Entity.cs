using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseApplication.Core.DomainObjects;

public abstract class Entity
{
    [Key][Column("id")] public int Id { get; protected set; }
    
    [Column("criado_em")] public DateTime CreatedAt { get; set; }
    [Column("atualizado_em")] public DateTime UpdatedAt { get; set; }
}