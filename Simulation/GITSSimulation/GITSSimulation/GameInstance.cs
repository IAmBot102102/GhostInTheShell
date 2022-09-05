using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GITSSimulation
{
    internal class GameInstance
    {
        List<Move> NextMoves = new List<Move>();
        List<Factory> Factories = new List<Factory>();
        List<Troop> Troops = new List<Troop>();
        List<Bomb> Bombs = new List<Bomb>();

        int[][] Metric;
        int IDMax = 0;
        
        public void Update()
        {
            for (int i = 0; i < NextMoves.Count; i++) 
            {
                Move currentMove = NextMoves[i];
                if (currentMove.WAIT == 1) { continue; }
                else if (currentMove.Number == -1)
                {
                    Bombs.Add(new Bomb(currentMove, IDMax, FactoryDistance(currentMove.TargetID, currentMove.SourceID)));
                }
                else 
                {
                    Troops.Add(new Troop());
                }
            }
        }
        public GameInstance() { }
        public GameInstance(int[][] Metric, List<Factory> Factories) { }

        public void PlayerTurn(int ownership) { }
        public void ComputerTurn(AIPlayer a, int ownership) { }    
        public void FileOutputData() { }
        public int FactoryDistance(int ID1, int ID2) { return Metric[ID1][ID2];  }
    }
}
