using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMotorPool.Cars;

namespace MyMotorPool.Pool
{
    class ManagerPool
    {
        MotorPool _pool;

        Client _client;

        public ManagerPool(MotorPool pool, Client client)
        {
            _pool = pool;

            _client = client;
        }

        public void DeliveryInHire()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Delivery in hire of the car");
            Console.ForegroundColor = ConsoleColor.Gray;

            _pool.ShowCars(_pool.Cars);

            int id = MotorPool.EnterYearOrId("id for delivery in hire");

            int num;

            for (num = 0; num < _pool.Cars.Count; num++)
            {
                if (_pool.Cars[num].Id == id)
                {
                    _pool.Cars[num].IsHire = true;

                    _client.SetOfTheCar(_pool.Cars[num]);

                    break;
                }
            }

            if (num == _pool.Cars.Count)
            {
                Console.WriteLine("In a motor pool there is no car with such id.");
            }
        }

        public void ReturningInHire()
        {
            int num;

            for (num = 0; num < _pool.Cars.Count; num++)
            {
                if (_pool.Cars[num].IsHire)
                {
                    _pool.Cars[num].IsHire = false;

                    break;
                }
            }
        }

        public void Show()
        {
            Console.Clear();

            MenuShow();

            switch (MotorPool.EnterNumber(5, () => MenuShow()))
            {
                case 1: _pool.ShowCarsNotSorting(); break;
                case 2: _pool.ShowCarsSortingOnMark(); break;
                case 3: _pool.ShowCarsSortingOnTypeOfBody(); break;
                case 4: _pool.ShowCarsSortingOnYearOfRelease(); break;
                case 5: _pool.ShowCarsSortingAsFuel(); break;
            }
        }

        void MenuShow()
        {
            Console.WriteLine("Choose type of fuel of the car:");

            string[] message = {
                                   "To display without sorting;",
                                   "To sort on mark of the car;",
                                   "To sort as a body of the car;",
                                   "To sort on a year of release of the car;",
                                   "To sort as fuel of the car."
                               };

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0} - {1};", i + 1, message[i]);
            }

            Console.Write("Enter number of type of fuel of the car: ");
        }

        public void AddCar()
        {
            _pool.AddCar();
        }

        public void RemoveCar()
        {
            _pool.RemoveCar();
        }

        public void RepairCar()
        {
            _pool.RepairCar();
        }
    }
}
