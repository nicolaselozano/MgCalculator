using System.ComponentModel.DataAnnotations;
using Cards.Models;

public class Abilitie
{  
    [Key]
    public Guid Id { get; set;}
    public List<Card> Cards{ get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}