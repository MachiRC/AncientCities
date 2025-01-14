using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class Program
{
        static public List <Rectangle> aRects = new List<Rectangle> { };
        static public List <Rectangle> sRects = new List<Rectangle> { };
        static public List <Triangle> aTris = new List<Triangle> { };
        static public List <Triangle> sTris = new List<Triangle> { };
        static public List <Circle> aCircs = new List<Circle> { };
        static public List <Circle> sCircs = new List<Circle> { };
        static public List <Trapezoid> aTraps = new List<Trapezoid> { };
        static public List <Trapezoid> sTraps = new List<Trapezoid> { };
        static double total = 0;

    public class Triangle
    {
        public double Base;
        public double Height;
    
    }
    public class Rectangle
    {
        public double rectLength;
        public double rectHeight;

    }

    public class Circle
    {
        public double radius;
        public bool isSemi;
    } 

    public class Trapezoid
    {
        public double base1;
        public double base2;
        public double height;
    }

    static public double CalcCity(List<Rectangle> addRects, List<Triangle> addTris, List<Circle> addCircs, List<Trapezoid> addTraps, List<Rectangle> subRects, List<Triangle> SubTris, List <Circle>SubCircs, List<Trapezoid> SubTraps)
    {
        //For anyone who's new to the stream, I'm just using slang guys


            for(int i = 0; i < addRects.Count; i++)
            {
                total += addRects[i].rectLength * addRects[i].rectHeight;
            }
            for(int i = 0; i < subRects.Count; i++)
            {
                total -= subRects[i].rectLength * subRects[i].rectHeight;
            }

            for(int i = 0; i < addTris.Count; i++)
            {
                total += (addTris[i].Base * addTris[i].Height)/2;
            }
            for(int i = 0; i < SubTris.Count; i++)
            {
                total -= (SubTris[i].Base * SubTris[i].Height) /2;
            }
            
            for(int i = 0; i < addCircs.Count; i++)
            {
                if(addCircs[i].isSemi)
                {
                    total += (Math.Pow(addCircs[i].radius, 2) * Math.PI)/2;
                }
                else
                {
                    total += Math.Pow(addCircs[i].radius, 2) * Math.PI;
                }
            }
        

            for(int i = 0; i < SubCircs.Count; i++)
            {
                if(SubCircs[i].isSemi)
                {
                    total -= (Math.Pow(SubCircs[i].radius, 2) * Math.PI)/2;
                }
                else
                {
                    total -= (Math.Pow(SubCircs[i].radius, 2) * Math.PI)/2;
                }
            }

            for(int i = 0; i < addTraps.Count; i++)
            {
                total += addTraps[0].height * (addTraps[0].base1 + addTraps[0].base2)/2;
            }
            for(int i = 0; i < SubTraps.Count; i++)
            {
                total -= SubTraps[0].height * (SubTraps[0].base1 + SubTraps[0].base2)/2;
            }
        
        return total;
    }

    static void AskUser()
    {

        string response = "";
        string response2 ="";
        string response3= "";
        
        RetryAS:
        
        Console.WriteLine("specify: add, sub");
        response = Console.ReadLine() ?? throw new ArgumentException("invalid input");
        
        if (response == "add" || response == "a" || response == "Add")
        {
            RetryAP:
            Console.WriteLine("specify: rect, tri, circ, trap");
            response = Console.ReadLine() ?? throw new ArgumentException("invalid shape");
            //PREPARE THE MEATBALLS, WE'RE HAVING SPAGHETTI CODE
            switch (response)
            {
                case "rect" or "Rect" or "Rectangle":
                    Console.WriteLine("specify: base length");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    aRects.Add(new Rectangle {rectLength=Convert.ToDouble(response), rectHeight = Convert.ToDouble(response2) });
                    break;

                case "tri" or "Tri" or "Triangle":
                    Console.WriteLine("specify: base");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    aTris.Add(new Triangle {Base=Convert.ToDouble(response), Height = Convert.ToDouble(response2) });
                    break;

                case "circ" or "Circ" or "Circle":
                    Console.WriteLine("specify: radius");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: is it a semicircle? true or false");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    aCircs.Add(new Circle {radius=Convert.ToDouble(response), isSemi = Convert.ToBoolean(response2) });
                    break;

                case "trap" or "Trap" or "Trapezoid":
                    Console.WriteLine("specify: first base");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: second base");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response3 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    aTraps.Add(new Trapezoid {base1 = Convert.ToDouble(response), base2 = Convert.ToDouble(response2), height = Convert.ToDouble(response3) });
                    break;
                    
                default:
                    goto RetryAP;
            }
        }
        else if (response == "sub" || response == "s" || response == "Sub")
        {
            RetrySP:
            Console.WriteLine("specify: rect, tri, circ, trap");
            response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
            switch (response)
            {
                case "rect" or "Rect" or "Rectangle":
                    Console.WriteLine("specify: base");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    sRects.Add(new Rectangle {rectLength=Convert.ToDouble(response), rectHeight = Convert.ToDouble(response2) });
                    break;

                case "tri" or "Tri" or "Triangle":
                    Console.WriteLine("specify: base");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    sTris.Add(new Triangle {Base=Convert.ToDouble(response), Height = Convert.ToDouble(response2) });
                    break;

                case "circ" or "Circ" or "Circle":
                    Console.WriteLine("specify: radius");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: is it a semicircle? true or false");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    sCircs.Add(new Circle {radius=Convert.ToDouble(response), isSemi = Convert.ToBoolean(response2) });
                    break;

                case "trap" or "Trap" or "Trapezoid":
                    Console.WriteLine("specify: first base length");
                    response = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: second base length");
                    response2 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    Console.WriteLine("specify: height");
                    response3 = Console.ReadLine() ?? throw new ArgumentException("invalid number");
                    sTraps.Add(new Trapezoid {base1 = Convert.ToDouble(response), base2 = Convert.ToDouble(response2), height = Convert.ToDouble(response3) });
                    break;
                    
                default:
                    goto RetrySP;
            }
        }
        else
        {
            Console.WriteLine("Reinput");
            goto RetryAS;
        }
        RetryAgain:
        Console.WriteLine("Again? y/n");
        response = Console.ReadLine() ?? throw new ArgumentException("invalid response");
        if (response == "y")
        {
            goto RetryAS;
        }
        else if (response == "n")
        {
            return;
        }
        else
        {
            goto RetryAgain;
        }
    }
    static void Main(String[] args)
    {
        AskUser();
        
        for (int i = 0; i > aRects.Count; i++)
        {
            Console.WriteLine(aRects[i].rectHeight);
        }

        Console.WriteLine(CalcCity(aRects, aTris, aCircs, aTraps, sRects, sTris, sCircs, sTraps));
    }
}