using System.ComponentModel.DataAnnotations;
using Cards.Models;
using CardsUsers.Models;

namespace Users.Models;
public class User
{
    [Key]
    public Guid Id { get; set; }
    [Required,StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public string? authId { get; set; }
    public bool isDeleted { get; set; } = false;
    public List<CardsUser>? CardsUsers { get; set; } = new List<CardsUser>();
    public List<Card>? Cards{ get; set; } = new List<Card>();
}