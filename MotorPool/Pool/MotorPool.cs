using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyMotorPool.Cars;

namespace MyMotorPool.Pool
{
    public class MotorPool
    {
        public List<Car> Cars { get; set; }

        static int countMarks = 10;

        static int countTypeOBody = 6;

        static int countFuel = 4;

        int consoleWidth;



        public MotorPool()
        {
            Inicilisation();
        }

        void Inicilisation()
        {
            consoleWidth = 190;

            Console.WindowWidth = consoleWidth;

            Cars = new List<Car>();

            Cars.Add(new Car(1, MarkOfCar.BMW, TypeOfBody.coupe, TypeOfFuelCar.gasoline, 2010, 2.5));
            Cars.Add(new Car(2, MarkOfCar.Honda, TypeOfBody.pickup, TypeOfFuelCar.diesel, 2015, 4.0));
            Cars.Add(new Car(3, MarkOfCar.Kia, TypeOfBody.hatchback, TypeOfFuelCar.gasoline, 2018, 1.6));
            Cars.Add(new Car(4, MarkOfCar.Mazda, TypeOfBody.sedan, TypeOfFuelCar.electricity, 2020, 0));
            Cars.Add(new Car(5, MarkOfCar.Nissan, TypeOfBody.pickup, TypeOfFuelCar.gasoline, 2018, 4.5));
        }



        public void ShowCars(List<Car> carsPool)
        {
            Console.Clear();

            List<Car> carsShow = carsPool;

            foreach (var item in carsShow)
            {
                Console.Write("Mark: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.Mark);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Type of a body: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.TypeOfBody);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Year of release: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.YearOfRelease);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Type of fuel: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.TypeOfFuel);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Volume of the engine: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item.VolumeOfTheEngine);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Serviceability: ");

                Console.ForegroundColor = ConsoleColor.Green;

                if (item.IsServiceability)
                {
                    Console.Write("It is serviceable.");
                }
                else
                {
                    Console.Write("It is not serviceable.");
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", In hire: ");

                Console.ForegroundColor = ConsoleColor.Green;

                if (item.IsHire)
                {
                    Console.Write("It is in hire.");
                }
                else
                {
                    Console.Write("It is not in hire.");
                }
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(", Id: ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(item.Id);
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(new string('-', consoleWidth));
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void ShowCarsNotSorting()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("In a motor pool there are following cars:");
            Console.WriteLine(new string('-', consoleWidth));
            Console.ForegroundColor = ConsoleColor.Gray;

            ShowCars(Cars);

            Console.ReadKey();
        }

        public void ShowCarsSortingOnMark()
        {
            Console.Clear();

            List<Car> carsSortingOnMark = new List<Car>();

            string mark = EnterMarkOrTypeOfBody("mark");

            var query = Cars.Where(item => item.Mark.ToString() == mark);

            foreach (var item in query)
            {
                carsSortingOnMark.Add(item);
            }

            if (carsSortingOnMark.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there are following cars of mark of {0}:", mark);
                Console.WriteLine(new string('-', consoleWidth));
                Console.ForegroundColor = ConsoleColor.Gray;

                ShowCars(carsSortingOnMark);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there is no car of mark of {0}", mark);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadKey();
        }

        public void ShowCarsSortingOnTypeOfBody()
        {
            Console.Clear();

            List<Car> carsSortingOnBody = new List<Car>();

            string body = EnterMarkOrTypeOfBody("type of body");

            var query = Cars.Where(item => item.TypeOfBody.ToString() == body);

            foreach (var item in query)
            {
                carsSortingOnBody.Add(item);
            }

            if (carsSortingOnBody.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool is available following cars with type of a body of {0}:", body);
                Console.WriteLine(new string('-', consoleWidth));
                Console.ForegroundColor = ConsoleColor.Gray;

                ShowCars(carsSortingOnBody);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there is no car with type of a body of {0}", body);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadKey();
        }

        public void ShowCarsSortingOnYearOfRelease()
        {
            Console.Clear();

            List<Car> carsSortingOnYear = new List<Car>();

            string message = "year of release";

            int year = EnterYearOrId(message);

            var query = Cars.Where(item => item.YearOfRelease == year);

            foreach (var item in query)
            {
                carsSortingOnYear.Add(item);
            }

            if (carsSortingOnYear.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there are following cars with a year of release {0}:", year);
                Console.WriteLine(new string('-', consoleWidth));
                Console.ForegroundColor = ConsoleColor.Gray;

                ShowCars(carsSortingOnYear);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there is no car with a year of release {0}", year);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadKey();
        }

        public void ShowCarsSortingAsFuel()
        {
            Console.Clear();

            List<Car> carsSortingOnBody = new List<Car>();

            string fuel = EnterMarkOrTypeOfBody("as fuel");

            var query = Cars.Where(item => item.TypeOfFuel.ToString() == fuel);

            foreach (var item in query)
            {
                carsSortingOnBody.Add(item);
            }

            if (carsSortingOnBody.Count != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there are following cars with type of fuel: {0}", fuel);
                Console.WriteLine(new string('-', consoleWidth));
                Console.ForegroundColor = ConsoleColor.Gray;

                ShowCars(carsSortingOnBody);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("In a motor pool there are no cars with type of fuel: {0}", fuel);
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            Console.ReadKey();
        }

        public static int EnterYearOrId(string message)
        {
            int year = 0;

            while (true)
            {
                Console.Write("Enter {0} of the car: ", message);

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    year = int.Parse(Console.ReadLine());

                    if (year <= 0)
                        // Closest exception.
                        throw new InvalidOperationException("Enter value > 0.");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (OverflowException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter an integer value, for example 7.");

                    continue;
                }
            }

            return year;
        }

        static string EnterMarkOrTypeOfBody(string message)
        {
            string markOrTypeOfBody = null;

            Console.Write("Enter the necessary {0} of the car: ", message);

            Console.ForegroundColor = ConsoleColor.Green;

            markOrTypeOfBody = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Gray;

            return markOrTypeOfBody;
        }

        public void AddCar()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Addition of the car in a motor pool.");
            Console.ForegroundColor = ConsoleColor.Gray;

            int id = EnterYearOrId("id");

            MarkOfCar mark = EnterMarkCar();

            TypeOfBody body = EnterTypeOfBody();

            TypeOfFuelCar type = EnterTypeOfFuelCar();

            Console.Clear();

            int year = EnterYearOrId("year of release");

            double volumeOfTheEngine;

            if (type == TypeOfFuelCar.electricity)
            {
                Console.Clear();

                volumeOfTheEngine = 0;
            }
            else
            {
                volumeOfTheEngine = EnterVolumeOfTheEngine();
            }

            Cars.Add(new Car(id, mark, body, type, year, volumeOfTheEngine));
        }

        void MenuAddMark()
        {
            Console.WriteLine("Choose mark of the car:");

            for (int i = 0; i < countMarks; i++)
            {
                Console.WriteLine("{0} - {1};", i + 1, ((MarkOfCar)i).ToString());
            }

            Console.Write("Enter number of mark of the car: ");
        }

        MarkOfCar EnterMarkCar()
        {
            MarkOfCar mark = MarkOfCar.Mersedes;
            
            Console.Clear();

            MenuAddMark();

            switch (EnterNumber(countMarks, () => MenuAddMark()))
            {
                case 1: mark = MarkOfCar.Mersedes; break;
                case 2: mark = MarkOfCar.BMW; break;
                case 3: mark = MarkOfCar.Opel; break;
                case 4: mark = MarkOfCar.Nissan; break;
                case 5: mark = MarkOfCar.Mazda; break;
                case 6: mark = MarkOfCar.Kia; break;
                case 7: mark = MarkOfCar.Shkoda; break;
                case 8: mark = MarkOfCar.Sitroen; break;
                case 9: mark = MarkOfCar.Mitsubisi; break;
                case 10: mark = MarkOfCar.Honda; break;
            }

            return mark;
        }

        void MenuAddTypeOfBody()
        {
            Console.WriteLine("Choose type of body of the car:");

            for (int i = 0; i < countTypeOBody; i++)
            {
                Console.WriteLine("{0} - {1};", i + 1, ((TypeOfBody)i).ToString());
            }

            Console.Write("Enter number of type of body of the car: ");
        }

        TypeOfBody EnterTypeOfBody()
        {
            TypeOfBody type = TypeOfBody.sedan;

            Console.Clear();

            MenuAddTypeOfBody();

            switch (EnterNumber(countTypeOBody, () => MenuAddTypeOfBody()))
            {
                case 1: type = TypeOfBody.sedan; break;
                case 2: type = TypeOfBody.coupe; break;
                case 3: type = TypeOfBody.wagon; break;
                case 4: type = TypeOfBody.hatchback; break;
                case 5: type = TypeOfBody.pickup; break;
                case 6: type = TypeOfBody.cabriolet; break;
            }

            return type;
        }

        TypeOfFuelCar EnterTypeOfFuelCar()
        {
            TypeOfFuelCar fuel = TypeOfFuelCar.gasoline;

            Console.Clear();

            MenuAddFuel();

            switch (EnterNumber(countFuel, () => MenuAddFuel()))
            {
                case 1: fuel = TypeOfFuelCar.diesel; break;
                case 2: fuel = TypeOfFuelCar.gasoline; break;
                case 3: fuel = TypeOfFuelCar.gas; break;
                case 4: fuel = TypeOfFuelCar.electricity; break;
            }

            return fuel;
        }

        void MenuAddFuel()
        {
            Console.WriteLine("Choose type of fuel of the car:");

            for (int i = 0; i < countFuel; i++)
            {
                Console.WriteLine("{0} - {1};", i + 1, ((TypeOfFuelCar)i).ToString());
            }

            Console.Write("Enter number of type of fuel of the car: ");
        }

        public static int EnterNumber(int number, Action action)
        {
            var numberMenu = 0;

            string message = string.Format("Enter a number from 1 to {0}: ", number);

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // The required menu number is entered, taking into account 
                // the overflow and the format of the entered number.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());

                    var condition = numberMenu > 0 && numberMenu < (number + 1);

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(message);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException(message);
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException(message);
                        }
                        else
                        {
                            Console.Clear();

                            action();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return numberMenu;
        }

        double EnterVolumeOfTheEngine()
        {
            double volume = 0;

            while (true)
            {
                Console.Write("Enter volume of the engine of the car: ");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    volume = double.Parse(Console.ReadLine());

                    if (volume <= 0)
                        // Closest exception.
                        throw new InvalidOperationException("Enter value > 0.");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (OverflowException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                    continue;
                }
            }

            return volume;
        }

        public void RemoveCar()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Removal of the car from park");
            Console.ForegroundColor = ConsoleColor.Gray;

            ShowCars(Cars);

            int id = EnterYearOrId("id for removal");

            int num;

            for (num = 0; num < Cars.Count; num++)
            {
                if (Cars[num].Id == id)
                {
                    Cars.Remove(Cars[num]);

                    break;
                }
            }

            if (num == Cars.Count)
            {
                Console.WriteLine("In a motor pool there is no car with such id.");
            }
        }

        public void RepairCar()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Repair of the car from park");
            Console.ForegroundColor = ConsoleColor.Gray;

            ShowCars(Cars);

            int id = EnterYearOrId("id for repair");

            int num;

            for (num = 0; num < Cars.Count; num++)
            {
                if (Cars[num].Id == id && !Cars[num].IsServiceability)
                {
                    Cars[num].Repair();

                    break;
                }
            }

            if (num == Cars.Count)
            {
                Console.WriteLine("In a motor pool there is no car with such id, or you have chosen the serviceable car.");
            }
        }
    }
}
