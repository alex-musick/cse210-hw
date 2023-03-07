using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Circle("red", 1) );
        shapes.Add(new Square("Blue", 2) );
        shapes.Add(new Rectangle("Green", 3, 4) );

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"{color}");
            Console.WriteLine($"{area}");

        }
    }
}