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

        public static void Setup(int[][] Metric, List<Factory> Factories) { }
        public static void Update() { }
        public static void RandomSetup() { }
        public static void PlayerTurn(int ownership) { }
        public static void ComputerTurn(AIPlayer a, int ownership) { }    
    }
}
