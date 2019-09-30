using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessKing1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int middle = 4;
            int x, y;
            int x1, y1;
            bool b;
            Console.WriteLine("Input position of king");
            do
            {
                Console.Write("X = ");
                b = int.TryParse(Console.ReadLine(), out x);
                if (b == false)
                    Console.WriteLine("Error ! : X!=Number!");
                else
                    if (x < 1 || x > 8)
                    Console.WriteLine("Error: Input x>0 and X <=8");
            } while (b == false || x < 1 || x > 8);

            do
            {
                Console.Write("Y = ");
                b = int.TryParse(Console.ReadLine(), out y);
                if (b == false)
                    Console.WriteLine("Error ! : Y!=Number!");
                else
                    if (y < 1 || y > 8)
                    Console.WriteLine("Error: Input y>0 and y <=8");
            } while (b == false || y < 1 || y > 8);

            Console.WriteLine("Input coord of step");

            do
            {
                Console.Write("X = ");
                b = int.TryParse(Console.ReadLine(), out x1);
                if (b == false)
                    Console.WriteLine("Error ! : X!=Number!");
                else
                    if (x1 < 1 || x1 > 8)
                    Console.WriteLine("Error: Input x>0 and X <=8");
            } while (b == false || x1 < 1 || x1 > 8);

            do
            {
                Console.Write("Y = ");
                b = int.TryParse(Console.ReadLine(), out y1);
                if (b == false)
                    Console.WriteLine("Error ! : Y!=Number!");
                else
                    if (y1 < 1 || y1 > 8)
                    Console.WriteLine("Error: Input y>0 and y <=8");
            } while (b == false || y1 < 1 || y1 > 8);

            if (x1 == x && y1 == y)
                Console.WriteLine("Error king is on the same place !");
            else
            {
                if (x1 >= x - 1 && x1 <= x + 1)
                {
                    if (y <= y1 + 1 && y >= y - 1)
                        Console.WriteLine(true);
                    else
                        Console.WriteLine(false);
                }
                else
                    Console.WriteLine(false);
                   
            }



         
        }
    }
}
//18.Дані координати(як цілі від 1 до 8) двох різних полів шахівниці.Якщо король за один хід може перейти з одного поля на 
//інше, вивести логічне значення True, інакше вивести значення False. 