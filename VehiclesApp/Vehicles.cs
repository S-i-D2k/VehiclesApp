using System;
using System.Collections.Generic;

namespace Vehicle.Data
{
    public class Vehicles
    {
        Random randomSeed = new Random();

        public enum Types
        {
            Car = 0,
            Boat = 1,
            Motorcycle = 2,
        }

        private List<IVehicle> _vehicles = new List<IVehicle>();

        public void Add(IVehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Remove(IVehicle vehicle)
        {
            _vehicles.Remove(vehicle);
        }

        public List<IVehicle> GetAll()
        {
            return _vehicles;
        }

        public IVehicle Select(IVehicle vehicle)
        {
            return _vehicles.Find(x => x == vehicle);
        }

        public int Count => _vehicles.Count;

        public IVehicle Factory(Types type)
        {
            IVehicle NewVehicle;

            // Generate a random number between 10 - 100.
            int randomNumber = randomSeed.Next(10, 100);

            // Create the new type
            switch (type)
            {
                case Types.Car:
                    NewVehicle = new Car();
                    break;
                case Types.Boat:
                    NewVehicle = new Boat();
                    break;
                case Types.Motorcycle:
                    NewVehicle = new Motorcycle();
                    break;
                default:
                    throw new ArgumentException("Trying to add an unknown type of Vehicle.");
            }

            // Set the speed on the new Vehicle
            NewVehicle.SetSpeed(randomNumber);

            return NewVehicle;
        }

        public List<IVehicle> GetCars() => _vehicles.FindAll(x => x is Car);
        public List<IVehicle> GetBoats() => _vehicles.FindAll(x => x is Boat);
        public List<IVehicle> GetMotorcycles() => _vehicles.FindAll(x => x is Motorcycle);

        public static void PrintSpeedInMetersPerSecond(IVehicle vehicleToPrint)
        {
            // The speed is defined as m/s (Metre Per Second)
            double SpeedInMPS = 0;

            // 1 mph = 0.44704 m/s
            if (vehicleToPrint is Car)
            {
                SpeedInMPS = vehicleToPrint.Speed * 0.44704;
            }

            // 1 knot = 0.51444444 m/s
            else if (vehicleToPrint is Boat)
            {
                SpeedInMPS = vehicleToPrint.Speed * 0.51444444;
            }

            // 1 km/h = 0.27777778 m/s
            else if (vehicleToPrint is Motorcycle)
            {
                SpeedInMPS = vehicleToPrint.Speed * 0.27777778;
            }
            
            Console.WriteLine($"{SpeedInMPS:0.0} m/s");
        }
    }
}
