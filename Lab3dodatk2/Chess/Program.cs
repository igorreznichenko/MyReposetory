using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {

            int y, y1;
            int x1, x;
            bool b;
            string value;
            Console.WriteLine("Input coord of figure");
          
            do
            {
                Console.Write("X = ");
                do {
                    value = Console.ReadLine();
                    if (value.Length != 1)
                        Console.WriteLine("Error: Input 1 number (a...h)");
                } while (value.Length != 1);
                    x = value[0];

                if (x < 'a' || x > 'h')
                    Console.WriteLine("Input number from a to h");
            } while (x < 'a' || x > 'h');

            do
            {
                Console.Write("Y =");
                value = Console.ReadLine();
                b = Int32.TryParse(value, out y);
                if (b == false)
                    Console.WriteLine("Error : Input string name");
                else
                {
                    if (y < 1 || y > 8)
                        Console.WriteLine("Input Y >0 and Y< 9");
                }
            } while (b == false || y < 1 || y > 8);

            Console.WriteLine("Write coord of step");

            do
            {
                Console.Write("X = ");
                do
                {
                    value = Console.ReadLine();
                    if (value.Length != 1)
                        Console.WriteLine("Error: Input 1 number (a...h)");
                } while (value.Length != 1);
                x1 = value[0];

                if (x1 < 'a' || x1 > 'h')
                    Console.WriteLine("Input number from a to h");
            } while (x1 < 'a' || x1 > 'h');


            do
            {
                Console.Write("Y = ");
                value = Console.ReadLine();
                b = Int32.TryParse(value, out y1);
                if (b == false)
                    Console.WriteLine("Error : Input string name");
                else
                {
                    if (y1 < 1 || y1 > 8)
                        Console.WriteLine("Input Y >0 and Y< 9");
                }
            } while (b == false || y1 < 1 || y1 > 8);

            if (x == x1 && y == y1)
                Console.WriteLine("this is the same position!");
            else
            if (x - x1 == y - y1)
                Console.WriteLine(true);
            else
                Console.WriteLine(false);

        }
    }
}
//19.Дані координати(як цілі від 1 до 8) двох різних полів шахівниці.
//Якщо слон за один хід може перейти з одного поля на інше, вивести логічне значення True, інакше вивести значення False.
//(з використанням Букв по вісі X (a..h)