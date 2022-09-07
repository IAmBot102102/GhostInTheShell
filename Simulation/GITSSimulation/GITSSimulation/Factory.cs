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
        public int XPos;
        public int YPos;
        public int ownership;
        public int DisabledCount = 0;

        public void SetPosition(int x, int y) { XPos = x; YPos = y; }
        public Factory(int ID, int ownership, int ProductionRate, int Number)
        {
            this.ID = ID;
            this.ProductionRate = ProductionRate;
            this.ownership = ownership;
            this.Number = Number;
        }
    }
}
