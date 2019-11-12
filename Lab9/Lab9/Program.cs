using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{

    interface IDraw
    {
        void Draw();
    }


    abstract class Triangle : IDraw {

        abstract public string Color {
            get;
            set;
        }
        abstract public double A_Length
        {
            get;
            set;
        }
        abstract public double B_Length
        {
            get;
            set;
        }
        abstract public double Angle_Length
        {
            get;
            set;
        }

        abstract public string Name
        {
            get;
        }
        abstract public void Draw();
        abstract public double Square();
        abstract public double Perimetr();
    }

    class EqTriangle : Triangle {

        private double a;
        private double b;
        private double c;
        private string name;
        private string color;


        public EqTriangle(double a, string name, string color)
        {
            this.color = color;
            this.a = a;
            b = c = a;
            this.name = name;
        }

        public override void Draw()
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("Color : {0}", color);
            Console.WriteLine("Side A = B = B =  {0}", a);
            Console.WriteLine("Square : {0}", Square());
            Console.WriteLine("Perimetr : {0}", Perimetr());
        }

        public override double A_Length
        {
            get
            {
                return a;
            }
            set { if (value <= 0)
                    Console.WriteLine("Not valid input !");
                else
                {
                    a = b = c = value;
                }

            }
        }
        public override double B_Length
        {
            get
            {
                return a;
            }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Not valid input !");
                else
                {
                    a = b = c = value;
                }

            }
        }

        public override double Angle_Length
        {
            get { return 45; }
            set { Console.WriteLine("Angle of EqTriangle is const = 45"); }
        }
        public override string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public override string Name
        {
            get
            {
                return name;
            }

        }
        public override double Square()
        {
            double s;
            s = a * a * (Math.Sqrt(3) / 4);
            return s;
        }

        public override double Perimetr()
        {
            return 3 * a;
        }
    }


    class IsTriangle : Triangle {
        private double a;
        private double b;
        private double c;
        private double angle;
        private string name;
        private string color;
        public IsTriangle(double a, double angle, string name, string color)
        {
            this.a = a;
            b = a;
            this.angle = angle;
            this.name = name;
            this.color = color;
        }
        public override void Draw()
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("Color : ", color);
            Console.WriteLine("Side A {0}", a);
            Console.WriteLine("Side B {0}", b);
            Console.WriteLine("Side C =  {0}", C_Length());
            Console.WriteLine("Square : {0}", Square());
            Console.WriteLine("Perimetr : {0}", Perimetr());
        }
        public double C_Length()
        {
            double C;
            C = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(angle/180*Math.PI));

            return C;
        }
        public override double A_Length {
            get
            {
                return a;
            }
            set
            {
                if (value < 1)
                    Console.WriteLine("Not valid side");
                else
                    a = b = value;
            }
        }

        public override double B_Length
        {
            get
            {
                return b;
            }
            set
            {
                if (value < 1)
                    Console.WriteLine("Not valid side");
                else
                    a = b = value;
            }
        }
        public override double Angle_Length {
            get
            {
                return angle;
            }
            set
            {
                if (angle < 1)
                    Console.WriteLine("Not valid angle !");
                else
                    angle = value;
            }
        }


        public override string Color
        {
            get
            {
                return Color;
            }
            set
            {
                Color = value;
            }
        }
        public override string Name
        {
            get { return Name; }
        }

        public override double Perimetr()
        {
            double p;
            p = a + b + C_Length();
            return p;
        }
        public override double Square()
        {
            double C = C_Length();
            double S;
            S = (1 / 2.0) * a * a * Math.Sin(angle/180*Math.PI);
            return S;
        }
    }

    class RectTriangle : Triangle{
        private double a;
        private double b;
        private double c;
        private double angle = 90;
        private string name;
        private string color;
        public RectTriangle(double a, double b, string name, string color)
        {
            this.a = a;
            this.b = b;
            this.name = name;
            this.color = color;
             Console.WriteLine(b);
        }
        public override void Draw()
        {
            Console.WriteLine("Name : {0}", name);
            Console.WriteLine("Color : ", color);
            Console.WriteLine("Side A {0}", a);
            Console.WriteLine("Side B {0}", b);
            Console.WriteLine("Side C =  {0}", C_Length());
            Console.WriteLine("Square : {0}", Square());
            Console.WriteLine("Perimetr : {0}", Perimetr());
        }

        public override double A_Length {
            get { return a;  }
            set { if (value < 1)
                    Console.WriteLine("Not valid input !");
                else
                {
                    a = value;                                      
                }
            }

        }

        public override double B_Length
        {
            get { return b; }
            set
            {
                if (value < 1)
                    Console.WriteLine("Not valid input !");
                else
                {
                    b = value;
                 
                }
            }
        }
        public override double Angle_Length {
            get
            {
                return angle;
            }
            set
            {
                Console.WriteLine("You can't change angle !");
            }
        }
        public override string Color {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public override string Name
        {
            get { return name; }
        }

        public double C_Length()
        {
            double C;

            C = Math.Sqrt(a * a + b * b);
            return C;

        }
        public override double Perimetr()
        {
            return a + b + C_Length();
        }

        public override double Square()
        {
            double S;
            S = a * b / 2;
            return S;
        }
    }

    class Picture : IDraw{
        List<Triangle> Triangles;
        int length;
        public void Draw()
        {
            if(Triangles.Count == 0)
            {
                Console.WriteLine("List is Empty !");
                return;
            }
            IDraw l;
            int i;
            for(i = 0; i< Triangles.Count; i++)
            {
                l = Triangles[i];
                l.Draw();
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                if (length < 1)
                    Console.WriteLine("Not valid input !");
                else
                length = value;
            }
        }
        public Picture(int length)
        {
            this.length = length;
            Triangles = new List<Triangle>(length);
        }
        public Picture() { }
        public Triangle this[int index]
        {
            get
            {
                if (index < 0 || index >= Triangles.Count)
                {
                    Console.WriteLine("Not valid index !");
                    return null;
                }
                else
                    return Triangles[index];
            }
        }

        public void addTriangle(EqTriangle q)
        {
            Triangles.Add(q);
        }
        public void addTriangle(IsTriangle q)
        {
            Triangles.Add(q);
        }
        public void addTriangle(RectTriangle q)
        {
            Triangles.Add(q);
        }

        public void Delete_Triangle(double Square)
        {
            if (Triangles.Count == 0)
            {
                Console.WriteLine("List is empty !");
                return;
            }

            foreach(Triangle i in Triangles){
                if(i.Square() > Square)
                {
                    Triangles.Remove(i);
                }
            }
        }
           public void Delete_Triangle(string Name)
        {
            if (Triangles.Count == 0)
            {
                Console.WriteLine("List is empty !");
                return;
            }

            foreach(Triangle i in Triangles){
                if(i.Name == Name)
                {
                    Triangles.Remove(i);
                }
            }
        }

        
        public void Delete_Triangle(EqTriangle t)
        {
            if (Triangles.Count == 0)
            {
                Console.WriteLine("List is empty !");
                return;
            }

            Triangles.Remove(t);
        }
        public void Delete_Triangle(IsTriangle t)
        {
            if (Triangles.Count == 0)
            {
                Console.WriteLine("List is empty !");
                return;
            }

            Triangles.Remove(t);
        }

        public void Delete_Triangle(RectTriangle t)
        {
            if (Triangles.Count == 0)
            {
                Console.WriteLine("List is empty !");
                return;
            }

            Triangles.Remove(t);
        }

    }
    class Painter
    {
        static public void Draw(EqTriangle t)
        {
            int h = 8;
            int i, j, k;
            for(i = 1; i<= h; i++)
            {
                for (j = h - i; j > 0; j--)
                    Console.Write(" ");
                for (k = 1; k <= i; k++)
                    Console.Write("* ");
                Console.WriteLine();

            }
            

        }
        static public void Draw(IsTriangle t)
        {
            int h = 8;
            int i, j, k, p;
            p = 1;
            for (i = 1; i <= h; i++)
            {
                for (j = (2*h-1) - p; j > 0; j--)
                    Console.Write(" ");
                for (k = 1; k <= p; k++)
                    Console.Write("* ");
                p += 2;
                Console.WriteLine();

            }
        }
        static public void Draw(RectTriangle t)
        {
            int h = 8;
            int i, j;
            for(i = 1; i<= h; i++)
            {
                for (j = 1; j <= i; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }

        }
    }


    class Program
    {
        static void Main()
        {
            EqTriangle b = new EqTriangle(34,"Triangle","blue");
            IsTriangle c = new IsTriangle(34, 45, "IsTriangle", "Red");
            RectTriangle d = new RectTriangle(3, 4, "Trinagle", "red");
            Painter.Draw(b);
            Painter.Draw(c);
            Painter.Draw(d);
        }
    }
}

