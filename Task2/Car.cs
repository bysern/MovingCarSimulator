using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Task2
{
    class Car
    {
        private string make;
        private string model;
        private Engine engine; //assuming that every car has only 1 engine (for hybrid use array np.)
        //calling 3 constructors from task 10
        public Car(string newMake, string newModel, double newDisplacement, double newAmountOfFuel,
            double newFuelTankCapacity) : this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel, newFuelTankCapacity))
        {
        }
        public Car(string newMake, string newModel, double newDisplacement,
                double newAmountOfFuel) : this(newMake, newModel, new Engine(newDisplacement, newAmountOfFuel))
        {
        }
        public Car(string newMake, string newModel, Engine newEngine)
        {
            this.make = newMake;
            this.model = newModel;
            this.engine = newEngine;
        }

        public void CarGo(double distance, int iteration)
        {
            int ParsedDouble = Convert.ToInt32(distance);

            string[] road = new string[ParsedDouble];
            string car = "O-O";

            for (int i = 0; i < road.Length; i++)
            {
                if (i != iteration)
                    road[i] = ".";

                road[iteration] = car;

                Console.Write(road[i]);
            }
        }

        public void Go(double howManyKm)
        {
            double start = howManyKm;
            int iteration = 0;
            Console.WriteLine("I'm riding");
            //loop will display animation on screen,  wait for 150ms
            while (howManyKm > 0)
            {
                //Console.SetCursorPosition(0, Console.CursorTop);
                //Console.Write("Distance to ride: {0,4}", howManyKm);
                Console.Clear();
                this.engine.Work();
                CarGo(start, iteration);
                Thread.Sleep(150);
                howManyKm--;
                iteration++;
                if (this.engine.AmountOfFuel <= 0) { Console.WriteLine(howManyKm + " kilometers left. You need to refuel"); break; };

            }
            Console.WriteLine("\nHere I am");
        }

        public void Refuel(double fuelAmount)
        {
            this.engine.Refuel(fuelAmount);
        }

        public double CheckFuel()
        {
            return engine.AmountOfFuel;
        }


    }
}
