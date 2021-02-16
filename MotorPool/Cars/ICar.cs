using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMotorPool.Cars
{
    public interface ICar
    {
        MarkOfCar Mark { get; set; }

        TypeOfBody TypeOfBody { get; set; }

        TypeOfFuelCar TypeOfFuel { get; set; }

        int YearOfRelease { get; set; }

        // автомобиль в движении.
        void Go();

        // автомобиль в ремонте.
        void Repair();
    }
}
