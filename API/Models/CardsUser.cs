using System.ComponentModel.DataAnnotations;
using Users.Models;

namespace CardsUsers.Models;

public class CardsUser
{  
    [Key]
    public Guid Id { get; set;}
    public User User { get; set; }
    public string MultiverseId { get; set; }

}