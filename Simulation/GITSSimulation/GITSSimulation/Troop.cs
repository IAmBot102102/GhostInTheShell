using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class Troop
    {
        public int ID;
        public int Number;
        public int targetID;
        public int sourceID;
        public int ETA;

        public Troop(int ID, int Number, int targetID, int sourceID, int ETA)
        {
            this.ID = ID;
            this.Number = Number;
            this.targetID = targetID;
            this.sourceID = sourceID;
            this.ETA = ETA;
        }
    }
}
