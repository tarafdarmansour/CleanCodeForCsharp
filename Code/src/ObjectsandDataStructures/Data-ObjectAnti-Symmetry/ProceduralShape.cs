using System.Drawing;

namespace Data_ObjectAnti_Symmetry.ProceduralShape;

public class Square
{
    public double side;
    public Point topLeft;
}

public class Rectangle
{
    public double height;
    public Point topLeft;
    public double width;
}

public class Circle
{
    public Point center;
    public double radius;
}

public class Geometry
{
    public const double PI = 3.141592653589793;

    public double area(object shape)
    {
        if (shape is Square square) return square.side * square.side;

        if (shape is Rectangle rectangle) return rectangle.height * rectangle.width;

        if (shape is Circle circle) return PI * circle.radius * circle.radius;

        throw new NoSuchShapeException();
    }
}

public class NoSuchShapeException : Exception
{
}