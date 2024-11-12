using System;

class Program
{
    static void Main(string[] args)
    {
        Rectangle Reggie = new Rectangle(2.5, 16, "Purple");
        Circle McQueen = new Circle(3, "Rustee Red");
        Square Maytor = new Square(3, "Brown");
        List<Shape> shapes = [Reggie, McQueen, Maytor];

        foreach (Shape shape in shapes)
        {
            
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }

    }
}