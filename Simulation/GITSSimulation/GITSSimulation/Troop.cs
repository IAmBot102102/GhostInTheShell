using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class Troop
    {
        public int ID = -1;
        public int Number = -1;
        public int targetID = -1;
        public int sourceID = -1;
        public int ETA = -1;
        public int ownership = -1;
        public bool enabled = true;

        public Troop(int ownership, int ID, int Number, int targetID, int sourceID, int ETA)
        {
            this.ID = ID;
            this.Number = Number;
            this.targetID = targetID;
            this.sourceID = sourceID;
            this.ownership = ownership;
            this.ETA = ETA;
        }
        public Troop(Move m, int ID, int ETA) 
        {
            this.ID = ID;
            this.ETA = ETA;
            this.targetID = m.TargetID;
            this.sourceID = m.SourceID;
            this.Number = m.Number;
            this.ownership = m.ownership;
        }
        public Troop() { }
    }
}
