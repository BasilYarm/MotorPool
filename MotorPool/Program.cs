using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMotorPool.Pool;
using MyMotorPool.Cars;
using System.Diagnostics;

namespace MyMotorPool
{
    class Program
    {
        static MotorPool motorPool = new MotorPool();

        static Client client = new Client();

        static ManagerPool manager = new ManagerPool(motorPool, client);

        static void Main(string[] args)
        {
            
            WorkingProgram();
            

            Console.ReadKey();
        }

        static void ProgramMenu()
        {
            Console.Clear();

            Console.WriteLine("1 - Work with the manager of a motor pool;");
            Console.WriteLine("2 - Work with the client;");
            Console.WriteLine("3 - Exit program.");

            Console.Write("Enter number of necessary action: ");
        }

        static void ManagerMenu()
        {
            Console.Clear();

            Console.WriteLine("1 - Viewing of data about cars;");
            Console.WriteLine("2 - Addition of the car;");
            Console.WriteLine("3 - Removal of the car;");
            Console.WriteLine("4 - Sending of the car in repair.");

            Console.Write("Enter number of necessary action: ");
        }

        static void ClientMenu()
        {
            Console.Clear();

            Console.WriteLine("1 - Capture of the car in hire;");
            Console.WriteLine("2 - Trip on the car;");
            Console.WriteLine("3 - Returning of the car in park.");

            Console.Write("Enter number of necessary action: ");
        }

        static void WorkingManager()
        {
            ManagerMenu();

            switch (MotorPool.EnterNumber(4, () => ManagerMenu()))
            {
                case 1: manager.Show(); break;

                case 2: manager.AddCar(); break;

                case 3: manager.RemoveCar(); break;

                case 4: manager.RepairCar(); break;
            }
        }

        static void WorkingClient()
        {
            //bool flag = true;

            //while (flag)
            //{
                ClientMenu();

                switch (MotorPool.EnterNumber(3, () => ClientMenu()))
                {
                    case 1: manager.DeliveryInHire(); break;

                    case 2:
                        {
                            if (client.Car.Id == 0)
                            {
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Before to go it is necessary to take the car in hire!");
                                Console.ForegroundColor = ConsoleColor.Gray;

                                Console.ReadKey();

                                goto case 1;
                            }
                            client.Trip();
                        }
                        break;

                    case 3:
                        {
                            //flag = false;

                            manager.ReturningInHire();
                        }
                        break;
                //}
            }
        }

        static void WorkingProgram()
        {
            while (true)
            {
                ProgramMenu();

                switch (MotorPool.EnterNumber(3, () => ProgramMenu()))
                {
                    case 1: WorkingManager(); break;

                    case 2: WorkingClient(); break;

                    case 3: ExitProgram(); break;
                }
            }
        }

        static void ExitProgram()
        {
            Client.systemPoolLog.Close();

            Environment.Exit(0);
        }
    }
}
