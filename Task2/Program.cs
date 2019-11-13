using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Engine.Lp100Km2MPG(6.4));
            Console.WriteLine("What is the make of your car?");
            string InputMake = Console.ReadLine();

            Console.WriteLine("What is the model of your car?");
            string InputModel = Console.ReadLine();
            Console.WriteLine("What is the displacement of you car?");
            double InputDisplacement;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out InputDisplacement) && (InputDisplacement > 0.5) && (InputDisplacement < 8)) break;
                Console.WriteLine("Wrong displacement input, try again");
            }
            Console.WriteLine("What is the amount of fuel of you car?");
            double InputAmountofFuel;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out InputAmountofFuel)) break;
                Console.WriteLine("Wrong Amount of fuel input, try again");
            }
            Console.WriteLine("How many km you want to drive");
            double InputHowManyKm;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out InputHowManyKm)) break;
                Console.WriteLine("Wrong Amount of km, try again");
            }

            //Car car = new Car("Mercedes", "C180",
            //    new Engine(1.8, 20));
            //car.Go(200);
            //Engine engine = new Engine(InputDisplacement, InputAmountofFuel);

            Car car = new Car(InputMake, InputModel, new Engine(InputDisplacement, InputAmountofFuel));
            car.Go(InputHowManyKm);
            do
            {
                Console.WriteLine("\nYou have " + car.CheckFuel() + " Liters of fuel left." + " \nTo refuel type: 'refuel' OR input how many km you want to drive again. \nType 'exit' to exit program");
                string InputAnswer = Console.ReadLine();
                if (InputAnswer == "refuel")
                {
                    Console.WriteLine("How many liters to refuel");
                    double InputLitersToRefuel;
                    while (true)
                    {
                        if (double.TryParse(Console.ReadLine(), out InputLitersToRefuel)) break;
                        Console.WriteLine("Wrong Input of liters");
                    }
                    car.Refuel(InputLitersToRefuel);
                }
                else if (InputAnswer == "exit") { Environment.Exit(0); break; }
                else
                {
                    double InputKMToGo;
                    while (true)
                    {
                        if (double.TryParse(InputAnswer, out InputKMToGo)) break;
                        Console.WriteLine("Wrong input try again");
                    }
                    car.Go(InputKMToGo);
                }
            } while (true);
            Console.ReadKey();
        }
    }
}
