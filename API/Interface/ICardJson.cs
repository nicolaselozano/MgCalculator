namespace ICardJson
{
    public class Ruling
    {
        public string Date { get; set; }
        public string Text { get; set; }
    }

    public class CLegality
    {   
        public string Format { get; set; }
        public string Legality { get; set; }
    }

    public class CardApiJson
    {
        public string Name { get; set; }
        public string ManaCost { get; set; }
        public double Cmc { get; set; }
        public List<string> Colors { get; set; }
        public List<string> ColorIdentity { get; set; }
        public string Type { get; set; }
        public List<string> Supertypes { get; set; }
        public List<string> Types { get; set; }
        public List<string> Subtypes { get; set; }
        public string Rarity { get; set; }
        public string Set { get; set; }
        public string SetName { get; set; }
        public string Text { get; set; }
        public string Artist { get; set; }
        public string Number { get; set; }
        public string Power { get; set; }
        public string Toughness { get; set; }
        public string Layout { get; set; }
        public string Multiverseid { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Variations { get; set; }
        public List<Ruling> Rulings { get; set; }
        public List<string> Printings { get; set; }
        public List<CLegality> Legalities { get; set; }
        public string Id { get; set; }
    }
}
