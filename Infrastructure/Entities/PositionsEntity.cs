using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Enteties;

public class PositionsEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Position { get; set; } = null!;

    public virtual ICollection<HockeyPlayersEntity> HockeyPlayers { get; set; } = new HashSet<HockeyPlayersEntity>();

}
