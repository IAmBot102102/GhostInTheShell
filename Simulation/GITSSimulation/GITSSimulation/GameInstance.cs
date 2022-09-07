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

        int BombCountPlayer1 = 0;
        int BombCountPlayer2 = 0;

        int[][] Metric;
        int IDMax = 0;
        
        public void Update()
        {
            UpdateFactories(); 
            MoveAndBattleTroops();
            MoveAndExplodeBombs();
            if (CheckIfWon() != 0) { Console.WriteLine("Wow."); }
        }
        public GameInstance() { }
        public GameInstance(int[][] Metric, List<Factory> Factories) { }
        public int CheckIfWon() { return 0; } // CHECK IF THE GAME HAS BEEN WON WOW SO COOL!
        public void ProductionRateIncreaseMoveHandler(Move currentMove) 
        {
            if (FindFactory(currentMove.TargetID) != -1)
            {
                if (Factories[currentMove.TargetID].Number >= 10 && Factories[currentMove.TargetID].ProductionRate < 3)
                {
                    Factories[currentMove.TargetID].Number -= 10;
                    Factories[currentMove.TargetID].ProductionRate += 1;
                }
            }
            else
            {
                // Add Debug things here probably.
            }
        }
        public void HandleMoves() 
        {
            for (int i = 0; i < NextMoves.Count; i++) 
            {
                Move currentMove = NextMoves[i];
                if (currentMove.type == MoveType.WAIT) { continue; }
                else if (currentMove.type == MoveType.PRODRATE) // Production Rate Increase
                {
                    ProductionRateIncreaseMoveHandler(currentMove);
                }
                else if (currentMove.type == MoveType.BOMB)
                {
                    BombCreationHandler(currentMove);
                }
                else
                {
                    TroopCreationHander(currentMove);
                }
            }
        }
        public void TroopCreationHander(Move currentMove)
        {
            if (FindFactory(currentMove.SourceID, currentMove.ownership) != -1)
            { 
                if (Factories[currentMove.SourceID].Number >= currentMove.Number) 
                {
                    Factories[currentMove.SourceID].Number -= currentMove.Number;
                    Troops.Add(new Troop(currentMove, IDMax, FactoryDistance(currentMove.TargetID, currentMove.SourceID)));
                }
            }
        }
        public void BombCreationHandler(Move currentMove) 
        {
            if (currentMove.ownership == 1) 
            {
                if (BombCountPlayer1 < 2) 
                {
                    Bombs.Add(new Bomb(currentMove, IDMax, FactoryDistance(currentMove.TargetID, currentMove.SourceID)));
                }
            }
            if (currentMove.ownership == -1) 
            {
                if (BombCountPlayer2 < 2) 
                {
                    Bombs.Add(new Bomb(currentMove, IDMax, FactoryDistance(currentMove.TargetID, currentMove.SourceID)));
                }
            }
        }
        public void UpdateFactories() 
        {
            foreach (Factory f in Factories) 
            {
                if (f.DisabledCount <= 0) { f.Number += f.ProductionRate; }
                else { f.DisabledCount -= 1; }
            }
        }
        public void MoveAndBattleTroops() 
        {
            foreach (Troop t in Troops) 
            {
                if (t.ETA == 1)
                {
                    if (FindFactory(t.targetID) != -1)
                    {
                        if (Factories[t.targetID].Number >= t.Number) { Factories[t.targetID].Number -= t.Number; }
                        else { 
                            Factories[t.targetID].Number = t.Number - Factories[t.targetID].Number;
                            Factories[t.targetID].ownership *= -1;
                        }
                    }
                    Troops.Remove(t);
                }
                else { t.ETA--; } 
            }
        }
        public void MoveAndExplodeBombs() 
        {
            foreach (Bomb b in Bombs) 
            {
                if (b.ETA == 1)
                {
                    if (FindFactory(b.targetID) != -1)
                    {
                        if (Factories[b.targetID].Number >= 20) { Factories[b.targetID].Number = (Factories[b.targetID].Number/2); }
                        else { 
                            Factories[b.targetID].Number -= 10;
                        }
                    }
                    Bombs.Remove(b);
                }
                else { b.ETA--; } 
            }
        }
        public int FindFactory(int ID) 
        {
            if (ID >= Factories.Count || ID < 0) { return -1;  }
            return ID; 
        }
        public int FindFactory(int ID, int ownership) 
        {
            if (FindFactory(ID) == -1) { return -1; }
            if (Factories[ID].ownership != ownership) { return -1; }
            return ID;
        }
        public int FindTroop(int ID) 
        {
            // TODO: We should probably implement Binary search
            // (considering that this is going to be run many times) but this is okay for now.
            for (int i = 0; i < Troops.Count; i++) 
            {
                if (Troops[i].ID == ID) { return i; }
            }
            return -1;
        }
        public void PlayerTurn(int ownership) { }
        public void ComputerTurn(AIPlayer a, int ownership) { }    
        public void FileOutputData() { }
        public int FactoryDistance(int ID1, int ID2) { return Metric[ID1][ID2];  }
    }
}
