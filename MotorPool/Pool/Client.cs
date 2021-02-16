using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMotorPool.Cars;
using System.Diagnostics;

namespace MyMotorPool.Pool
{
    public class Client : INotificationSystem
    {
        public static EventLog systemPoolLog;

        public Car Car { get; set; }

        //public string Name { get; set; }

        public Client()//string name)
        {
            //Name = name;

            Car = new Car();

            systemPoolLog = new EventLog();
        }

        public void SetOfTheCar(Car car)
        {
            Car = car;

            Car.show += ShowConsole;

            Car.show += ShowSystem;
        }

        public void Trip()
        {
            Car.Go();
        }

        public void ShowSystem(string message)
        {
            if (!EventLog.SourceExists("MyPoolLog"))
            {
                EventLog.CreateEventSource("MyPoolLog", "PoolLog");
            }

            systemPoolLog.Source = "MyPoolLog";

            systemPoolLog.WriteEntry(message);
        }

        public void ShowConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
