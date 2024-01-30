using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Enteties;

public class NationalitiesEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string Nationality { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; } = null!;


    public virtual ICollection<HockeyPlayersEntity> HockeyPlayers { get; set; } = new HashSet<HockeyPlayersEntity>();
}
