

using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

class Program
{
    public bool hasCircle;
    public bool hasTriangle;
    public bool hasRectangle;
    public bool hasTrap;
    public bool rectSub;
    public bool triSub;
    public bool circSub;
    public bool trapSub;
    public double CalcCity(List <Rectangle> addRects, List <Triangle> addTris, List <Circle> addCircs, List<Trapezoid> addTraps, List <Rectangle> subRects, List <Triangle> SubTris, List <Circle> SubCircs, List <Trapezoid> SubTraps)
    {
        //For anyone who's new to the stream, I'm just using slang guys
        double total = 0;

        if(rectSub!)
        {
            for(int i = 0; i < addRects.Count; i++)
            {
                total += addRects[i].rectLength * addRects[i].rectHeight;
            }
        }
        else
        {
            for(int i = 0; i < subRects.Count; i++)
            {
                total -= subRects[i].rectLength * subRects[i].rectHeight;
            }
        }
    
        if(triSub!)
        {
            for(int i = 0; i < addTris.Count; i++)
            {
                total += (addTris[i].Base * addTris[i].Height)/2;
            }
        }
        else
        {
            for(int i = 0; i < SubTris.Count; i++)
            {
                total -= (SubTris[i].Base * SubTris[i].Height) /2;
            }
        }
    
        if(circSub!)
        {
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
        }
        
        else
        {
            for(int i = 0; i <SubCircs.Count; i++)
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
        }
        
        if(trapSub!)
        {
            for(int i = 0; i < addTraps.Count; i++)
            {
                total += addTraps[0].height * (addTraps[0].base1 + addTraps[0].base2)/2;
            }
        }
        
        else
        {
            for(int i = 0; i < SubTraps.Count; i++)
            {
                total -= SubTraps[0].height * (SubTraps[0].base1 + SubTraps[0].base2)/2;
            }
        }
    
        
        return total;
    }

    public void AskUser(List <Rectangle> addRects, List <Triangle> addTris, List <Circle> addCircs, List<Trapezoid> addTraps, List <Rectangle> subRects, List <Triangle> SubTris, List <Circle> SubCircs, List <Trapezoid> SubTraps)
    {

        bool addSub;
        string response;
        string response2;
        string response3;
        
        RetryAS:
        
        Console.WriteLine("specify: add, sub");
        response = Console.ReadLine();
        
        if (response == "add")
        {
            RetryAP:
            Console.WriteLine("specify: rect, tri, circ, trap");
            response = Console.ReadLine();
            //PREPARE THE MEATBALLS, WE'RE HAVING SPAGHETTI
            switch (response)
            {
                case "rect" or "Rect" or "Rectangle":
                    Console.WriteLine("specify: base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine();
                    addRects.Add(new Rectangle {rectLength=Convert.ToDouble(response), rectHeight = Convert.ToDouble(response2) });
                    break;

                case "tri" or "Tri" or "Triangle":
                    Console.WriteLine("specify: base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine();
                    addTris.Add(new Triangle {Base=Convert.ToDouble(response), Height = Convert.ToDouble(response2) });
                    break;

                case "circ" or "Circ" or "Circle":
                    Console.WriteLine("specify: radius");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: is it a semicircle? true or false");
                    response2 = Console.ReadLine();
                    addCircs.Add(new Circle {radius=Convert.ToDouble(response), isSemi = Convert.ToBoolean(response2) });
                    break;

                case "trap" or "Trap" or "Trapezoid":
                    Console.WriteLine("specify: first base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: second base length");
                    response2 = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response3 = Console.ReadLine();
                    addTraps.Add(new Trapezoid {base1 = Convert.ToDouble(response), base2 = Convert.ToDouble(response2), height = Convert.ToDouble(response3) });
                    break;
                    
                default:
                    goto RetryAP;
            }
        }
        else if (response == "sub")
        {
            RetrySP:
            Console.WriteLine("specify: rect, tri, circ, trap");
            response = Console.ReadLine();
            switch (response)
            {
                case "rect" or "Rect" or "Rectangle":
                    Console.WriteLine("specify: base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine();
                    subRects.Add(new Rectangle {rectLength=Convert.ToDouble(response), rectHeight = Convert.ToDouble(response2) });
                    break;

                case "tri" or "Tri" or "Triangle":
                    Console.WriteLine("specify: base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response2 = Console.ReadLine();
                    SubTris.Add(new Triangle {Base=Convert.ToDouble(response), Height = Convert.ToDouble(response2) });
                    break;

                case "circ" or "Circ" or "Circle":
                    Console.WriteLine("specify: radius");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: is it a semicircle? true or false");
                    response2 = Console.ReadLine();
                    SubCircs.Add(new Circle {radius=Convert.ToDouble(response), isSemi = Convert.ToBoolean(response2) });
                    break;

                case "trap" or "Trap" or "Trapezoid":
                    Console.WriteLine("specify: first base length");
                    response = Console.ReadLine();
                    Console.WriteLine("specify: second base length");
                    response2 = Console.ReadLine();
                    Console.WriteLine("specify: height");
                    response3 = Console.ReadLine();
                    SubTraps.Add(new Trapezoid {base1 = Convert.ToDouble(response), base2 = Convert.ToDouble(response2), height = Convert.ToDouble(response3) });
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
    }


    static void Main()
    {
        List <Rectangle> rects = new List<Rectangle> { };
        List <Triangle> tris = new List<Triangle> { };
        List <Circle> circs = new List<Circle> { };
        List <Trapezoid> traps = new List<Trapezoid> { };
        
        
    }

    class Triangle
    {
        public double Base;
        public double Height;
    
    }
    class Rectangle
    {
        public double rectLength;
        public double rectHeight;

    }

    class Circle
    {
        public double radius;
        public bool isSemi;
    } 

    class Trapezoid
    {
        public double base1;
        public double base2;
        public double height;
    }

}