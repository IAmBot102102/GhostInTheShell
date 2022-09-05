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
        public int TargetID;
        public int SourceID;
        public int Number;

        public Move(int TargetID, int SourceID, int Number){ this.TargetID = TargetID; this.SourceID = SourceID; this.Number = Number; }
        public Move(int TargetID, int SourceID){ this.TargetID = TargetID; this.SourceID = SourceID; }
        public Move() { WAIT = 1; }
        
    }
}
