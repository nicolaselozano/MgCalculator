namespace CardsJson;
public class BoundingPolygon
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Word
{
    public string Text { get; set; }
    public List<BoundingPolygon> BoundingPolygon { get; set; }
    public double Confidence { get; set; }
}

public class Line
{
    public string Text { get; set; }
    public List<BoundingPolygon> BoundingPolygon { get; set; }
    public List<Word> Words { get; set; }
}

public class TextDocument
{
    public List<Line> Lines { get; set; }
}
