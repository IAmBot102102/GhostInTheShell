using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class Bomb
    {
        public int ID;
        public int targetID;
        public int sourceID;
        public int ETA;

        public Bomb(int ID, int targetID, int sourceID, int ETA)
        {
            this.ID = ID;
            this.targetID = targetID;
            this.sourceID = sourceID;
            this.ETA = ETA;
        }
    }
}
