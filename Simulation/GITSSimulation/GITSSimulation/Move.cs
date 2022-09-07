using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    public enum MoveType { WAIT, TROOP, BOMB, PRODRATE }
    internal class Move
    {
        public int TargetID = -1;
        public int SourceID = -1;
        public int Number = -1;
        public int ownership = -1;
        public MoveType type = MoveType.WAIT;
        public Move(int ownership, int TargetID, int SourceID, int Number)
        { 
            this.TargetID = TargetID; this.SourceID = SourceID;
            this.Number = Number; this.ownership = ownership; 
            type = MoveType.TROOP;
        }
        public Move(int ownership, int TargetID, int SourceID)
        {
            this.ownership = ownership;
            this.TargetID = TargetID; this.SourceID = SourceID;
            type = MoveType.BOMB;
        }
        public Move(int targetID) 
        {
            this.TargetID = targetID;
            type = MoveType.PRODRATE;
        }
        public Move() { }
        
    }
}
