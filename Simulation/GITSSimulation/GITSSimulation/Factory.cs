using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class Factory
    {
        public int ID;
        public int ProductionRate;
        public int Number;

        public Factory(int ID, int ProductionRate, int Number)
        {
            this.ID = ID;
            this.ProductionRate = ProductionRate;
            this.Number = Number;
        }
    }
}
