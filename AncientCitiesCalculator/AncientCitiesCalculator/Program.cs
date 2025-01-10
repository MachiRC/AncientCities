

using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

class Program
{
    
    static void Main()
    {
        List <double> rects = new List<double> { };
        List <Triangle> tris = new List<Triangle> { };
        List <double> circles = new List<double> { };
        
        Console.WriteLine("How many Triangles are in the Monument?");
        int triAmount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many Rectangles are in the Monument?");
        int rectAmount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many SemiCircles are in the Monument?");
        int semcircAmount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many Trapezoids are in the Monument?");
        int trapAmount = Convert.ToInt32(Console.ReadLine());

        tris[0].Height = 1;
        

        double sumOfShapes = Rectangle(3, 6) + SemiCircle(5) + Trapezoid(7, 9, 7);

        Console.WriteLine(sumOfShapes);
    }

    class Triangle
    {
        public double Base;
        public double Height;
        
    
    }
    
    static double Rectangle(double length, double height)
    {
        double rectLength = length * height;
        return rectLength;

    }

    static double SemiCircle(double radius)
    {
        double circumference = Math.PI * Math.Pow(radius, radius);
        circumference /= 2;
        Math.Round(circumference);
        return circumference;
    } 

    static double Trapezoid(double base1, double base2, double trapHeight)
    {
        double baseSum = base1 + base2;
        baseSum /= 2;
        baseSum *= trapHeight;
        Math.Round(baseSum);
        return baseSum;
    }
}