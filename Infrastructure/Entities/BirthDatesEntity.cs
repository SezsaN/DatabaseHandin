using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Enteties;

public class BirthDatesEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "varchar(5)")]
    public string BirthYear { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(2)")]
    public string BirthMonth { get; set; } = null!;
    [Required]
    [Column(TypeName = "varchar(2)")]
    public string BirthDay { get; set; } = null!;

    public virtual ICollection<HockeyPlayersEntity> HockeyPlayers { get; set; } = new HashSet<HockeyPlayersEntity>();

}
