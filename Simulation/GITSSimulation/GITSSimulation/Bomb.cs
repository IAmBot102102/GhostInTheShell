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
        public int ownership;

        public Bomb(int ownership, int ID, int targetID, int sourceID, int ETA)
        {
            this.ID = ID;
            this.targetID = targetID;
            this.sourceID = sourceID;
            this.ETA = ETA;
            this.ownership = ownership;
        }
        public Bomb(Move m, int ID, int ETA) 
        {
            this.ID = ID;
            this.targetID = m.TargetID;
            this.sourceID = m.SourceID;
            this.ETA = ETA;
            this.ownership = m.ownership;
        }
    }
}
