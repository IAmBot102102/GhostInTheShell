using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    abstract class AIPlayer
    {
        public int ownership;

        public abstract Move Move(GameInstance g); 
    }
}
