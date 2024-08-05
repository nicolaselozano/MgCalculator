using System.ComponentModel.DataAnnotations;
using Cards.Models;
using Users.Models;

namespace CardsUsers.Models;

public class CardsUser
{  
    [Key]
    public Guid Id { get; set;}
    public Guid CardId { get; set; }
    public User User { get; set; }
    public Card Card { get; set; }
    public Guid UserId { get; set; }

}