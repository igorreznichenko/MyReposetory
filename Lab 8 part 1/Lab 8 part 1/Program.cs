using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_part_1
{
    class Auto
    {
        public string name;
        public string color;
        public int year;
        public Auto(string Name, string Color, int Year)
        {
            name = Name;
            year = Year;
            color = Color;
        }
    }
    class Garage_Of_Sheikh
    {
        public List<Auto> auto = new List<Auto>();

        public void ShowCars()
        {
            if(auto.Count == 0)
            {
                Console.WriteLine("Error : Garage is empty !");
                return;
            }
            foreach(Auto l in auto){
                Console.WriteLine("Auto : " + l.name);
                Console.WriteLine("Color : " + l.color);
                Console.WriteLine("Year : " + l.year);
                Console.WriteLine();
            }
        }
        public void ChooseCar()
        {
            if (auto.Count == 0)
            {
                Console.WriteLine("Error : Garage is empty !");
                return;
            }
            bool b;
            string name;
            string color;
            int year;
            Console.WriteLine("Input parameters, if parametr isn't mandatory input 0");
            Console.WriteLine("Input name");
            name = Console.ReadLine();
            Console.WriteLine("Color : ");
            color = Console.ReadLine();
            Console.WriteLine("Year : ");
            
            do
            {
                b = int.TryParse(Console.ReadLine(), out year);
                if (b == false)
                    Console.WriteLine("Error : You try to input string value !");
                if (year < 0)
                    Console.WriteLine("Input positive number !");

            } while (year < 0 || b == false);
             foreach(Auto car in auto)
            {
                if(car.name == name || name == "0")
                    if (car.color == color || color=="0")
                        if (car.year == year || year == 0)
                        {
                            Console.WriteLine("Auto : " + car.name);
                            Console.WriteLine("Color : " + car.color);
                            Console.WriteLine("Year : " + car.year);
                            Console.WriteLine();
                        }
            }

          
        }
        public bool DeleteCar()
        {
            if (auto.Count == 0)
            {
                Console.WriteLine("Error : Garage is empty !");
                return false;
            }
            bool b;
            string name;
            string color;
            int year;
            Console.WriteLine("Input parameters, if parametr isn't mandatory input 0");
            Console.WriteLine("Input name");
            name = Console.ReadLine();
            Console.WriteLine("Color : ");
            color = Console.ReadLine();
            Console.WriteLine("Year : ");

            do
            {
                b = int.TryParse(Console.ReadLine(), out year);
                if (b == false)
                    Console.WriteLine("Error : You try to input string value !");
                if (year < 1)
                    Console.WriteLine("Input positive number !");

            } while (year < 1 || b == false);

            b = auto.Remove(new Auto(name, color, year));
            return b;
        }

        public void BuyNewCar() {
          
            bool b;
            string name;
            string color;
            int year;
            Console.WriteLine("Input name");
            name = Console.ReadLine();
            Console.WriteLine("Color : ");
            color = Console.ReadLine();
            Console.WriteLine("Year : ");

            do
            {
                b = int.TryParse(Console.ReadLine(), out year);
                if (b == false)
                    Console.WriteLine("Error : You try to input string value !");
                if (year < 1)
                    Console.WriteLine("Input positive number !");

            } while (year < 1 || b == false);

            auto.Add(new Auto(name, color, year));

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Garage_Of_Sheikh Garage = new Garage_Of_Sheikh();
            int i;
            bool b;
            do
            {
                Console.WriteLine("1 : See the cars");
                Console.WriteLine("2 : Choose car");
                Console.WriteLine("3 : Delete car");
                Console.WriteLine("4 : Buy new car");
                Console.WriteLine("5 : Exit");
                do
                {
                    Console.Write("Your choice is : ");
                    b = int.TryParse(Console.ReadLine(), out i);
                    if (b == false)
                        Console.WriteLine("Error : You try to input string value !");
                    else
                    {
                        if (i < 1 || i > 4)
                            Console.WriteLine("Input i>=1 and i <=4");
                    }

                } while (b == false || i < 1 || i > 4);

                switch (i) {
                    case 1:
                        {
                            Garage.ShowCars();
                            break;
                        }
                    case 2:
                        {
                            Garage.ChooseCar();
                            break;
                        }
                    case 3:
                        {
                            if (Garage.DeleteCar())
                                Console.WriteLine("Delete  complete");
                            else
                                Console.WriteLine("Delete didn't Complete");
                            break;
                        }
                    case 4:
                        {
                            Garage.BuyNewCar();
                            break;
                        }
                }
               
               
            } while (i != 5);
           
        }
    }
}