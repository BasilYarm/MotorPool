using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyMotorPool.Cars
{
    public class Car : ICar, IHire
    {
        public delegate void Show(string message);

        public event Show show;
        
        public int Id { get; set; }

        public MarkOfCar Mark { get; set; }

        public TypeOfBody TypeOfBody { get; set; }

        public TypeOfFuelCar TypeOfFuel { get; set; }

        public int YearOfRelease { get; set; }

        public double VolumeOfTheEngine { get; set; }

        // Исправность.
        public bool IsServiceability { get; set; }

        // Находится в прокате.
        public bool IsHire { get; set; }

        public Car()
        {
            Id = 0;

            Mark = MarkOfCar.BMW;

            TypeOfBody = TypeOfBody.sedan;

            TypeOfFuel = TypeOfFuelCar.gasoline;

            YearOfRelease = 2020;

            VolumeOfTheEngine = 2000;

            IsServiceability = true;

            IsHire = false;
        }

        public Car(int id, MarkOfCar mark, TypeOfBody typeOfBody, TypeOfFuelCar typeOfFuel, int yearOfRelease, double volumeOfTheEngine)
        {
            Id = id;

            Mark = mark;
            
            TypeOfBody = typeOfBody;

            TypeOfFuel = typeOfFuel;

            YearOfRelease = yearOfRelease;

            VolumeOfTheEngine = volumeOfTheEngine;

            IsServiceability = true;

            IsHire = false;
        }

        public void Go()
        {
            Console.Clear();

            Random timeInAWay = new Random();

            int temp = (int)timeInAWay.Next(22);

            Random breakage = new Random();

            string message = string.Format("The car a {0} (id: {1}) in a way", Mark.ToString(), Id);

            // вывод сообщения о том что машина в пути
            Display(message);
   
            for (int time = 0; time < temp; time++)
            {
                if ((int)breakage.Next(1000) > 950)
                {
                    IsServiceability = false;

                    message = string.Format("The car a {0} (id: {1}) has broken and requires under repair", Mark.ToString(), Id);

                    // вывод сообщения о том, что машина сломалась и нуждается в ремонте.
                    Display(message);

                    Console.ReadKey();

                    IsHire = false;

                    break;
                }

                Thread.Sleep(1000);
            }

            if (IsServiceability)
            {
                message = string.Format("The car a {0} (id: {1}) has stopped movement", Mark.ToString(), Id);

                // вывод сообщения о том, что машина прекратила движение 
                Display(message);

                Console.ReadKey();
            }
        }

        public void Repair()
        {
            Console.Clear();

            Random timeOfRepair = new Random();

            int temp = (int)timeOfRepair.Next(14);

            string message = null; 

            if (temp > 12)
            {
                message = string.Format("For the car a {0} (id: {1})  repair is impossible", Mark.ToString(), Id);

                // вывод сообщения о том, что ремонт не возможен.
                Display(message);

                Console.ReadKey();
            }
            else
            {
                message = string.Format("For the car a {0} (id: {1})  is under repair", Mark.ToString(), Id);

                // вывод сообщения о том, что машина в ремонте.
                Display(message);

                for (int time = 0; time < temp; time++)
                {
                    Thread.Sleep(1000);
                }

                message = string.Format("For the car a {0} (id: {1})  repair is ended", Mark.ToString(), Id);

                // вывод сообщения о том, что машина вышла из ремонта.
                Display(message);

                IsServiceability = true;

                Console.ReadKey();
            }
        }

        public void HireOfTheCar()
        {
            IsHire = true;

            // вывод сообщения о том, что машина находится в прокате.
        }

        void Display(string message)
        {
            if (show != null)
            {
                show.Invoke(message);
            }
        }
    }
}
