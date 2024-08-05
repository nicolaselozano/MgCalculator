using System.ComponentModel.DataAnnotations;
using CardsUsers.Models;
using Users.Models;

namespace Cards.Models;

public class Card
{  
    [Key]
    public Guid Id { get; set;}
    public List<User>? Users { get; set; } = new List<User>();
    public List<CardsUser>? CardsUsers{ get; set; } = new List<CardsUser>();
    public string MultiverseId { get; set; }
    public bool isDeleted { get; set; } = false;

}