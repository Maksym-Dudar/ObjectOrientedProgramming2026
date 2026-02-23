public abstract class Shape
{
    public abstract double Area { get; }
}

public class Rectangle : Shape
{
    public virtual double Height { get; set; }
    public virtual double Width { get; set; }
    public override double Area => Height * Width;
}

public class Square : Shape
{
    public double Side { get; set; }
    public override double Area => Side * Side;
}

public class Execution
{
    public void ShowArea(Shape shape)
    {
        Debug.WriteLine($"Area: {shape.Area}");
    }
}