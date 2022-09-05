using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class Move
    {
        public int WAIT = 0;
        public int TargetID = -1;
        public int SourceID = -1;
        public int Number = -1;
        public int ownership = -1;

        public Move(int ownership, int TargetID, int SourceID, int Number)
        { 
            this.TargetID = TargetID; this.SourceID = SourceID; 
            this.Number = Number; this.ownership = ownership; 
        }
        public Move(int ownership, int TargetID, int SourceID)
        {
            this.ownership = ownership;
            this.TargetID = TargetID; this.SourceID = SourceID;
        }
        public Move(int targetID) 
        {
            this.TargetID = targetID;
        }
        public Move() { WAIT = 1; }
        
    }
}
