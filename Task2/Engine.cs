using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Engine
    {
        //constant value declaration (can be public we dont need to hide it inside class)
        private const double Mile = 1.609334; //per km
        private const double Gallon = 3.785411784; // per ltr
        private readonly double Displacement; //we dont change engine or tank after creation so we cannot change it after thats why its readonly

        private const double DefaultFuelTankCapacity = 50;
        //private readonly double defaultFuelTankCapacity = 50;  const is better solution 

        private readonly double FuelTankCapacity;
        public double AmountOfFuel;

        //declaring public constructor
        public Engine (double newDisplacement, double newAmountOfFuel)
        {
            this.Displacement = newDisplacement;
            this.AmountOfFuel = newAmountOfFuel;
            this.FuelTankCapacity = DefaultFuelTankCapacity; //setting fuel tank capacity to the default value
        }
        //second constructor , we can use this constructor to create car with different tank capacity, first we do first constructor and
        //then return to body of second constructor
        public Engine(double newDisplacement, double newAmountOfFuel, double newFuelTankCapacity):this(newDisplacement, newAmountOfFuel)
        {
            this.FuelTankCapacity = newFuelTankCapacity;
        }

        //converters that will be always available because they are static (dont require object)
        public static double MPG2Lp100Km(double MPG)  
        {
            return (100 * Gallon) / (Mile * MPG);
        }
        // without static we would have to write new Engine() in program.cs to call it
         public static double Lp100Km2MPG (double Lp100Km)
        {
            return (100 * Gallon) / (Mile * Lp100Km);
        }
        public void Work()
        {
         this.AmountOfFuel -= (4 * this.Displacement) / 100;
            try
            {
                if (this.AmountOfFuel <= 0) throw new InvalidOperationException();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("\n You run out of fuel.");
            }
        }

        public void Refuel(double fuelAmount)
        {
            if (this.AmountOfFuel + fuelAmount > this.FuelTankCapacity)
            {
                throw new InvalidOperationException("Fuel on shoes - too much fuel");
            }

            this.AmountOfFuel += fuelAmount;

        }

    }
}
