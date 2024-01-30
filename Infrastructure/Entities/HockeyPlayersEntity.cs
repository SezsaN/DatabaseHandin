using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Enteties;

public class HockeyPlayersEntity
{

    [Key]
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string FirstName { get; set; } = null!;
    [Required]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(ClubsEntity))]
    public int ClubId { get; set; }
    public virtual ClubsEntity Club { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(BirthDatesEntity))]
    public int BirthDateId { get; set; }
    public virtual BirthDatesEntity BirthDate { get; set; } = null!;
    
    [Required]
    [ForeignKey(nameof(PositionsEntity))]
    public int PositionId { get; set; }
    public virtual PositionsEntity Position { get; set; } = null!;
   
    [Required]
    [ForeignKey(nameof(NationalitiesEntity))]
    public int NationalityId { get; set; }
    public virtual  NationalitiesEntity Nationality { get; set; } = null!;


}
