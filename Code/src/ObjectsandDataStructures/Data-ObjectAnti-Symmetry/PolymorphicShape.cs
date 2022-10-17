using System.Drawing;

namespace Data_ObjectAnti_Symmetry.PolymorphicShape;

public class Shape
{
}

public class Square : Shape
{
    private double side;
    private Point topLeft;

    public double area()
    {
        return side * side;
    }
}

public class Rectangle : Shape
{
    private double height;
    private Point topLeft;
    private double width;

    public double area()
    {
        return height * width;
    }
}

public class Circle : Shape
{
    public const double PI = 3.141592653589793;
    private Point center;
    private double radius;

    public double area()
    {
        return PI * radius * radius;
    }
}