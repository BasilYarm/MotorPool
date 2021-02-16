using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMotorPool.Cars
{
    public interface IHire
    {
        bool IsHire { get; set; }

        void HireOfTheCar();
    }
}
