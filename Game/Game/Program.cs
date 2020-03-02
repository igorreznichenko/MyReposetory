using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate bool Give_Symb1(string sign);
    public delegate bool Check();
    class Game_Race
    {
        int amount;
        string[] cars;
        int[] arr;
        public int Get_Amount{
            get
            {
                return amount;
            }
        }
        
        public Game_Race(int n)
        {
            amount = n;
            arr = new int[amount];
            for (int i = 0; i < amount; i++)
                arr[i] = 1;
            cars = new string[n];
        }
        public Give_Symb1 Drive;
        public Check Check_Array;
        
        void Choose_Cars()
        {
            int i;
            string s;
            bool b;
            for (i = 0; i< amount; i++)
            {
                Console.Write("Player" + (i+1) + " Your Car is :");
                do
                {
                    s = Console.ReadLine();
                    b = Check_On_Repeat(s, i);
                    if (b)
                        Console.Write("This car is Choosen ! Input other car !");

                } while (b);
                cars[i] = s;
            }
        }

        bool Check_On_Repeat(string sight, int pos)
        {
            for(int i = 0; i< pos; i++)
            {
                if (cars[i] == sight)
                    return true;
            }
            return false;
        }
        void GiveField()
        {
            for(int i = 0; i< amount; i++) 
            Console.WriteLine("|                    |");
            

        }
        int check_position(string sigh)
        {
            int i;
           for(i = 0; i< amount; i++)
            {
                if (cars[i] == sigh)
                    return i;
            }
           
           return -1;
        }
       public bool print_pos(string  sign)
        {
            int p = check_position(sign);
            if (p != -1)
            {
                Console.SetCursorPosition(arr[p], p);
                arr[p]++;
                Console.Write(cars[p]);
                return false;
            }
            return true;
        }

        public bool Check_Arr()
        {
            for(int i = 0; i< arr.Length; i++)
            {
                if (arr[i] > 20)
                    return false;
            }
            return true;
        }

        public int Check_Winner()
        {
            int i = 0;
            while (arr[i] < 20)
                i++;
            return i;
        }

        public void Play_Game()
        {
           
            Choose_Cars();
            Console.Clear();
            GiveField();
            string s;
            bool b;
            int Winner;
            do
            {   
                do
                {
                    s = Console.ReadKey().KeyChar.ToString();
                    Console.CursorLeft -= 1;
                    Console.Write(" ");
                    Console.CursorLeft -= 1;
                    Console.Write("");
                    b = Drive(s);
                } while (b);
                
            } while (Check_Array());

            Winner = Check_Winner();
            Console.SetCursorPosition(0, amount+1);
            Console.WriteLine("Player " + (Winner+1) + " With car <" + cars[Winner] + "> Win !");
        }

    }
    class Program
    {
 
        static void Main(string[] args)
        {

            int n;
            bool b;
            Console.WriteLine("Amount of players : ");
            do
            {
                b = int.TryParse(Console.ReadLine(), out n);
                if (!b)
                    Console.WriteLine("Error : Not valid Input !");

            } while (!b);
            Game_Race game = new Game_Race(n);
            game.Check_Array = game.Check_Arr;
            game.Drive = game.print_pos;

            game.Play_Game();
           
        }
    }
}
