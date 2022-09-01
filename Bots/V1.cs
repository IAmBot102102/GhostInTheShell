using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
 
// Offense Mode Version 1
//Hello Auri





 

class Troop {
    /// <summary>The integer <c>entityID</c> is the ID of the object.</summary>
    public int entityID;
    /// <summary>The integer <c>ownership</c> dictates the player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</summary>
    public int ownership;
    /// <summary>The integer <c>sourceFactoryID</c> is the factory ID where the troop has come from.</summary>
    public int sourceFactoryID;
    /// <summary>The integer <c>targetFactoryID</c> is the factory ID where the troop is going.</summary>
    public int targetFactoryID;
    /// <summary>The integer <c>cyborgNumber</c> is the number of cyborgs in the troop.</summary>
    public int cyborgNumber;
    /// <summary>The integer <c>eta</c> is the number of turns until the troop arrives at the target factory.</summary>
    public int eta;

    /// <summary>This method is a constructor for the Factory class.</summary>
    /// <param name="entityID">The integer <c>entityID</c> is the ID of the object.</param>
    /// <param name="ownership">The integer <c>ownership</c> dictates the player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</param>
    /// <param name="sourceFactoryID">The integer <c>sourceFactoryID</c> is the factory ID where the troop has come from.</param> 
    /// <param name="targetFactoryID">The integer <c>targetFactoryID</c> is the number of cyborgs in the troop.</param> 
    /// <param name="cyborgNumber">The integer <c>cyborgNumber</c> is the number of cyborgs in the troop.</param> 
    /// <param name="eta">The integer <c>eta</c> is the number of turns until the troop arrives at the target factory.</param> 
    public Troop(int entityID, int ownership, int sourceFactoryID, int targetFactoryID, int cyborgNumber, int eta){
        this.entityID = entityID;
        this.ownership = ownership;
        this.sourceFactoryID = sourceFactoryID;
        this.targetFactoryID = targetFactoryID;
        this.cyborgNumber = cyborgNumber;
        this.eta = eta;
    }
}


class Factory {
    /// <summary>The integer <c>entityID</c> is the ID of the object.</summary>
    public int entityID;
    /// <summary>The integer <c>ownership</c> dictates the player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</summary>
    public int ownership;
    /// <summary>The integer <c>cyborgNumber</c> is the number of cyborgs in the factory.</summary>
    public int cyborgNumber;
    /// <summary>The integer <c>productionRate</c> is the number of cyborgs gained per turn (between 0 and 3)</summary>
    public int productionRate;

    /// <summary>This method is a constructor for the Factory class.</summary>
    /// <param name="entityID">The integer <c>entityID</c> is the ID of the object.</param>
    /// <param name="ownership">The integer <c>ownership</c> dictates the player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</param>
    /// <param name="cyborgNumber">The integer <c>cyborgNumber</c> is the number of cyborgs in the factory.</param> 
    /// <param name="productionRate">The integer <c>productionRate</c> is the number of cyborgs gained per turn (between 0 and 3)</param> 
    public Factory(int entityID, int ownership, int cyborgNumber, int productionRate){
        this.entityID = entityID;
        this.ownership = ownership;
        this.cyborgNumber = cyborgNumber;
        this.productionRate = productionRate;
    }
}

// TODO: Add a bomb class
class Bomb{
    public int entityID;
    public int ownership;
    public int sourceFactoryID;
    public int targetFactoryID;
    public int eta;
    /// <summary>This method is a constructor for the Factory class.</summary>
    /// <param name="entityID">The integer <c>entityID</c> is the ID of the object.</param>
    /// <param name="ownership">The integer <c>ownership</c> dictates the player that owns the factory: 1 for you, -1 for your opponent and 0 if neutral</param>
    /// <param name="sourceFactoryID">The integer <c>sourceFactoryID</c> is the factory ID where the bomb has come from.</param> 
    /// <param name="targetFactoryID">The integer <c>targetFactoryID</c> is the ID of the target factory. -1 if it's the opponent's bomb</param> 
    /// <param name="eta">The integer <c>eta</c> is the number of turns until the troop arrives at the target factory. -1 if it's your opponent's bomb</param> 
    public Bomb(int entityID, int ownership, int sourceFactoryID, int targetFactoryID, int eta){
        this.entityID = entityID;
        this.ownership = ownership;
        this.sourceFactoryID = sourceFactoryID;
        this.targetFactoryID = targetFactoryID;
        this.eta = eta;
    }
}
class Player
{
    /// <summary> The matrix <c>METRIC</c> determines the distance between two factories that are given.</summary>
    public static int[ , ] METRIC;
    /// <summary>The integer <c>factoryCount</c> is the amount of factories in the game.</summary>
    public static int factoryCount;
    /// <summary>The integer <c>entityCount</c> is the amount of entities in the game.</summary>
    public static int entityCount;
    /** 
    <summary>
        The variable <c>currentTroops</c> is an array of troops that are in the game currently. 
        In order to search for a specific troop, you need to use the <code>TroopBinarySearch(int troopID)</code> function
        and input the ID of the troop you want to find.
    </summary>
    **/
    public static Troop[] currentTroops;
    /** 
    <summary>
        The variable <c>currentFactories</c> is an array of factories that are in the game currently. 
        Put the ID of the factory (then subtract 1) inside of this array and it outputs a "Factory" object with the factory 
        data inside of it.
        <code>currentFactories[IDOfFactory-1] = FactoryObject</code>
    </summary>
    **/
    public static Factory[] currentFactories;
    // TODO: ADD DOCUMENTATION FOR THIS
    public static int bombCount = 0;
    /// <summary>The variable <c>playerScore</c> is an integer containing the player's score.</summary>
    public static int playerScore = 0;
    /// <summary>The variable <c>enemyScore</c> is an integer containing the enemy's score.</summary>
    public static int enemyScore = 0;
    /// <summary>The variable <c>timeElapsed</c> is an integer the number of turns that have elapsed in the game.</summary>
    public static int timeElapsed = 0;
    /// <summary><c>shuffledArmies</c> determines (when a bomb has been launched) if the armies have been shuffled around yet.</summary>
    public static bool shuffledArmies = false;
    /// <summary><c>currentBombs</c> is an array of all the bombs that have been launched.</summary>
    public static Bomb[] currentBombs;
    /// <summary><c>playerBombs</c> is an array of all the bombs that have been launched by the player.</summary>
    public static Bomb[] playerBombs;
    /// <summary><c>enemyBombs</c> is an array of all the bombs that have been launched by the enemy.</summary>
    public static Bomb[] enemyBombs;
    /// <summary>The integer array <c>armies</c> contains the IDs of factories that contain the armies that we're using.</summary>
    public static Factory[] armies;
    /// <summary>The integer array <c>resources</c> contains the IDs of factories that are not armies.</summary>
    public static Factory[] resources;
    /// <summary> <c>playerFactories</c> is the array of factories that are owned by the player.</summary>
    public static Factory[] playerFactories;
    /// <summary> <c>enemyFactories</c> is the array of factories that are owned by the enemy.</summary>
    public static Factory[] enemyFactories;
    /// <summary> <c>neutralFactories</c> is the array of factories that are owned by no one.</summary>
    public static Factory[] neutralFactories;
    /// <summary> <c>nonPlayerFactories</c> is the array of factories that are owned by everyone but the player. (Neutral and Enemy).</summary>
    public static Factory[] nonPlayerFactories;
    /// <summary> <c>playerTroops</c> is the array of troops that are owned by the player.</summary>
    public static Troop[] playerTroops;
    /// <summary> <c>enemyTroops</c> is the array of troops that are owned by the enemy.</summary>
    public static Troop[] enemyTroops;
    /// <summary>It's value is 1. This is a variable to more clearly define when we're using calculations that involve the player.</summary>
    public static int PLAYER = 1;
    /// <summary>It's value is -1. This is a variable to more clearly define when we're using calculations that involve the enemy.</summary>
    public static int ENEMY = -1;
    /// <summary>It's value is 0. This is a variable to more clearly define when we're using calculations that involve neutral factories.</summary>
    public static int NEUTRAL = 0;
    /// <summary>The method <c>ProductionRateDefenseModeThreshold</c> returns the threshold number such that if a number returned by ModeSelectionFunction is greater than that, it is in ProductionRateDefenseMode instead of regular DefenseMode.</summary>
    public static float ProductionRateDefenseModeThreshold(){
        // TODO: Make an actual mathematical function for this (preferably using probability theory)
        return -3;
    }
    /// <summary>The method <c>ModeSelectionFunction</c> separates the choices into defense and offense.</summary>
    public static float ModeSelectionFunction(){
        // TODO: Just finish this function
        return 1f;
    }
    /// <summary>The method <c>ProductionRateDefenseMode</c>chooses who to defend and how in emergencies. It returns the troops needed to be sent in an array.</summary>
    public static Troop[] ProductionRateDefenseMode(){return new Troop[1];}
    /// <summary>The method <c>DefenseMode</c>chooses who to defend and how when being attacked. It returns the troops needed to be sent in an array.</summary>
    public static Troop[] DefenseMode(){ 
        // First check to see if any bombs have been launched, if so we need to move the armies around
        List<Troop> output = new List<Troop>();
        // TODO: IMPLEMENT SHIFTING ARMIES AROUND!
        
        if(enemyBombs.Length == 0){
            shuffledArmies = true;
            // UPDATE LOCATIONS OF ARMIES

            // CHOOSE WHERE TO PUT THE ARMIES
            List<Factory> armyList = armies.ToList();
            List<Factory> resourcesList = resources.ToList();
            for(int i = 0; i < armyList.Count; i++){
                if(currentFactories[armyList[i].entityID].ownership == ENEMY){
                    armyList.Remove(armyList[i]);
                }
            }
            for(int i = 0; i < resourcesList.Count; i++){
                if(currentFactories[resourcesList[i].entityID].ownership == ENEMY){
                    resourcesList.Remove(resourcesList[i]);
                }
            }
            for(int i = 0; i < playerFactories.Length; i++){
                bool matching = false;
                for( int j = 0; j < resources.Length; j++){
                    if(resources[j].entityID == playerFactories[i].entityID){
                        matching = true;
                    }
                }
                for( int j = 0; j < armies.Length; j++){
                    if(armies[j].entityID == playerFactories[i].entityID){
                        matching = true;
                    }
                }
                if(matching == false){
                    resourcesList.Add(playerFactories[i]);
                }
            }
            
            armies = armyList.ToArray();
            resources = resourcesList.ToArray();
            Console.Error.WriteLine("BEFORE");
            DisplayFactoryData(armies);
            DisplayFactoryData(resources);
            int w = 0;
            while(w != armyList.Count){
                if(CyborgNumberSum(TroopsTargetting(armyList[w].entityID)) > 0){
                    resourcesList.Add(armyList[w]);
                    armyList.Remove(armyList[w]);
                }
                else{
                    w++;
                }
            }
            

            w = 0;
            while(w != resourcesList.Count){
                if(CyborgNumberSum(TroopsTargetting(resourcesList[w].entityID)) < 0){
                    armyList.Add(resourcesList[w]);
                    resourcesList.Remove(resourcesList[w]);
                    
                }
                else{
                    w++;
                }
            }

            armies = armyList.ToArray();
            resources = resourcesList.ToArray();
            Console.Error.WriteLine("AFTER");
            DisplayFactoryData(armies);
            DisplayFactoryData(resources);
            

            Factory[] armiesSortedByNeed = MostTargettedSort(armies);
            for(int i = 0; i < armiesSortedByNeed.Length; i++){
                Factory[] resourcesSortedByMETRIC = METRICSort(armiesSortedByNeed[i].entityID, resources);
                for(int j = 0; j < resourcesSortedByMETRIC.Length; j++){
                    int n = NumberOfTroopsToSend(resourcesSortedByMETRIC[j].entityID, armiesSortedByNeed[i].entityID);
                    if(n != 0 && currentFactories[resourcesSortedByMETRIC[j].ownership].entityID == PLAYER){
                        output.Add(new Troop(0, 1, resourcesSortedByMETRIC[j].entityID, armiesSortedByNeed[i].entityID, n, 0));
                        currentFactories[resourcesSortedByMETRIC[j].entityID].cyborgNumber -= n;
                    }
                    Console.Error.WriteLine("COME ON ");
                }
            }
            for(int i = 0; i < armiesSortedByNeed.Length; i++){
                for(int j = 0; j < armies.Length; j++){
                    int n = NumberOfTroopsToSend(armies[j].entityID, armiesSortedByNeed[i].entityID);
                    if(n != 0 && currentFactories[armies[j].entityID].ownership == PLAYER){
                        output.Add(new Troop(0, 1, armies[j].entityID, armiesSortedByNeed[i].entityID, n, 0));
                        currentFactories[armies[j].entityID].cyborgNumber -= n;
                    }
                    
                }
            }
            for(int i = 0; i < armies.Length; i++){
                if(currentFactories[armies[i].entityID].cyborgNumber > 17){
                    Console.Write("INC " + armies[i].entityID+";");
                }
            }
            for(int i = 0; i < resources.Length; i++){
                if(currentFactories[resources[i].entityID].cyborgNumber > 17){
                    Console.Write("INC " + resources[i].entityID + ";");
                }
            }

        }
        if(enemyBombs.Length != 0 && shuffledArmies == false){
            List<Factory> armyList = armies.ToList();
            List<Factory> resourcesList = resources.ToList();
            for(int i = 0; i < armyList.Count; i++){
                if(currentFactories[armyList[i].entityID].ownership == ENEMY){
                    armyList.Remove(armyList[i]);
                }
            }
            for(int i = 0; i < resourcesList.Count; i++){
                if(currentFactories[resourcesList[i].entityID].ownership == ENEMY){
                    resourcesList.Remove(resourcesList[i]);
                }
            }
            armies = armyList.ToArray();
            resources = resourcesList.ToArray();
            if(armies.Length == 1){
                if(resources.Length == 0){
                    if(neutralFactories.Length == 0){
                        for(int i = 0; i < armies.Length; i++){
                            Console.Write("MOVE " + armies[i].entityID + " " + enemyFactories[0].entityID + " " + armies[i].cyborgNumber + ";");
                        }
                    }
                    else{
                        for(int i = 0; i < armies.Length; i++){
                            Console.Write("MOVE " + armies[i].entityID + " " + neutralFactories[0].entityID + " " + armies[i].cyborgNumber + ";");
                        }
                    }
                }
                else{
                    for(int i = 0; i < armies.Length; i++){
                        Console.Write("MOVE " + armies[i].entityID + " " + resources[0].entityID + " " + armies[i].cyborgNumber + ";");
                    }
                }
            }
            
            
        }
        
        return output.ToArray();
    }
    /// <summary>The method <c>OffenseMode</c> chooses who to atttack and how. It returns the troops needed to be sent in an array.</summary>
    public static Troop[] OffenseMode(){
        
        // TODO: Make Offense Mode change strategies based on the time elapsed.
        
        /* Hold strategy
        
        */


        if(timeElapsed < 3){
            // TODO: Fill out just expansion phase.
            return ExpansionPhase();
        }
        if(BombShootingDeterminate() > 0){
            return BombAttack();
        }
        // TODO: Fill out Army Attack phase.
        return ArmyAttack();

    }
    public static float BombShootingDeterminate(){
        return -1f;
    }
    public static Troop[] BombAttack(){// TODO: Work the bomb explosions into the simulation.
        return new Troop[1];
    }
    public static Troop[] ArmyAttack(){
        List<Troop> output = new List<Troop>();

        for(int j = 0; j < armies.Length; j++){
            Factory[] nonPlayerFactoriesSorted;
            if(neutralFactories.Length == 0){
                 nonPlayerFactoriesSorted = METRICSort(armies[j].entityID, enemyFactories);
                for(int i = nonPlayerFactoriesSorted.Length-1; i > -1; i--){
                int n = NumberOfTroopsToSend(armies[j].entityID, nonPlayerFactoriesSorted[i].entityID);
                if(n != 0 && currentFactories[armies[j].entityID].ownership == PLAYER){
                    output.Add(new Troop(0, 1, armies[j].entityID, nonPlayerFactoriesSorted[i].entityID, n, 0));
                    currentFactories[armies[j].entityID].cyborgNumber -= n;
                }
            }
            }
            else{
                nonPlayerFactoriesSorted = CyborgNumberSort(neutralFactories);
                for(int i = nonPlayerFactoriesSorted.Length-1; i > -1; i--){
                int n = NumberOfTroopsToSend(armies[j].entityID, nonPlayerFactoriesSorted[i].entityID);
                if(n != 0 && currentFactories[armies[j].entityID].ownership == PLAYER){
                    output.Add(new Troop(0, 1, armies[j].entityID, nonPlayerFactoriesSorted[i].entityID, n, 0));
                    currentFactories[armies[j].entityID].cyborgNumber -= n;
                }
            }
            }
            
        }
        if(bombCount < 2){
            Factory[] sorted = (CyborgNumberSort(enemyFactories));//, playerFactories);
            if(bombCount == 1){
                if( CyborgNumberSort(enemyFactories)[0].entityID == playerBombs[0].targetFactoryID && enemyFactories.Length > 1 && currentFactories[sorted[sorted.Length-1].entityID].ownership == PLAYER){
                    
                    Console.Write("BOMB " + sorted[sorted.Length-1].entityID + " " + CyborgNumberSort(enemyFactories)[1].entityID + ";");
                    bombCount++;
                    return output.ToArray();
                }
                
            }
            if(sorted[sorted.Length-1].ownership != PLAYER){
                return output.ToArray();
            }

            Console.Write("BOMB " + sorted[sorted.Length-1].entityID + " " + CyborgNumberSort(enemyFactories)[0].entityID + ";");
            bombCount++;
            
            
        }
        return output.ToArray();
    }
    public static Troop[] ExpansionPhase(){
        List<Troop> output = new List<Troop>();
        
        Factory[] playerFactoriesSorted = CyborgNumberSort(playerFactories);
        for(int j = 0; j < playerFactoriesSorted.Length; j++){
            Factory[] nonPlayerFactoriesSorted = METRICSort(playerFactoriesSorted[j].entityID, neutralFactories);
            for(int i = nonPlayerFactoriesSorted.Length-1; i > -1; i--){
                int n = NumberOfTroopsToSend(playerFactoriesSorted[j].entityID, nonPlayerFactoriesSorted[i].entityID);
                if(n > 0 && currentFactories[playerFactoriesSorted[j].entityID].cyborgNumber >= n){
                    output.Add(new Troop(-1, 1, playerFactoriesSorted[j].entityID, nonPlayerFactoriesSorted[i].entityID, n, 0)); 
                    currentFactories[playerFactoriesSorted[j].entityID].cyborgNumber -= n;
                    List<Troop> currentTroopsEdited = currentTroops.ToList();
                    currentTroopsEdited.Add(new Troop(-1, 1, playerFactoriesSorted[j].entityID, nonPlayerFactoriesSorted[i].entityID, n, 0));
                    currentTroops = currentTroopsEdited.ToArray();
                    
                }
                if(output.Count >= 6){
                    return output.ToArray();
                }
            }
            
        }
        return output.ToArray();
    }
    /// <summary>The method <c>TroopBinarySearch</c> (given a troop ID) will return the index of the currentTroops array such that the troop there has the same ID as the one inputted into the function.</summary>
    /// <param name="troopID">The integer <c>troopID</c> is the ID of the troop that you are looking for.</param>
    /// <param name="boundLeft">The integer <c>boundLeft</c> the left bound of the binary search.</param>
    /// <param name="boundRight">The integer <c>boundRight</c> the right bound of the binary search.</param> 
    public static int TroopBinarySearch(int troopID, int boundLeft = 0, int boundRight = -1) {
        int boundRightCorrected = boundRight;
        if(boundRight == -1){ boundRightCorrected = currentTroops.Length-1; }
        
        int k = ((boundRightCorrected-boundLeft)/2);

        if(boundRightCorrected - boundLeft == 1){
            if(currentTroops[boundRightCorrected].entityID == troopID){ return boundRightCorrected;}
            if(currentTroops[boundLeft].entityID == troopID){ return boundLeft; }
            
        }
        
        if(currentTroops[k].entityID > troopID){
            return TroopBinarySearch(troopID, boundLeft, k-1);
        }
        if(currentTroops[k].entityID < troopID){
            return TroopBinarySearch(troopID, k+1, boundRightCorrected);
        }
        return k;
        
    }
    /// <summary>The method <c>ReturnOutput</c> takes an array of Troops and sends them off. </summary>
    /// <param name='output'> The Troop array <c>output</c> is the array of troops to be sent off.</param>
    public static void ReturnOutput(Troop[] output){
        if(output.Length == 0) {Console.WriteLine("WAIT"); return;}
        for(int i = 0; i < output.Length; i++){
            Console.Write("MOVE " + output[i].sourceFactoryID + " " + output[i].targetFactoryID + " " + output[i].cyborgNumber + ";");
        }
        Console.WriteLine("MSG Complexity :" + (output.Length));
    }
    /// <summary>The method <c>ProductionRateSort</c> takes an array of factories and sorts them (in descending order) of the most production rate.</summary>
    /// <param name='inputFactoryList'> The array of factories that you want to sort by descending production rate.</param>
    public static Factory[] ProductionRateSort(Factory[] inputFactoryList){
        Factory[] output = new Factory[inputFactoryList.Length];
        inputFactoryList.CopyTo(output, 0);

        
        
        
        int pointer1 = 0;
        int pointer2 = 1;

        if(output.Length == 1 || output.Length == 0){ return output; }

        if(output.Length == 2){
            if(output[pointer1].productionRate < output[pointer2].productionRate){
                Factory temp1 = output[pointer1];
                Factory temp2 = output[pointer2];

                output[pointer2] = temp1;
                output[pointer1] = temp2;
                
            }
            return output;
        }
        
        while(pointer1 < output.Length){
            if(output[pointer1].productionRate < output[pointer2].productionRate){
                Factory temp = output[pointer2];

                for(int i = pointer2-1; i >= pointer1; i--){
                    output[i+1] = output[i];
                }
                output[pointer1] = temp;

            }

            pointer2++;
            if(pointer2 == output.Length){
                pointer2 = pointer1+2;
                pointer1 += 1;
                if(pointer2==output.Length){break;}
            }
            
        }
        return output;
    }
    /// <summary>The method <c>CyborgNumberSort</c> takes an array of factories and sorts them (in descending order) of the most cyborgNumber.</summary>
    /// <param name='inputFactoryList'> The array of factories that you want to sort by descending cyborgNumber.</param>
    public static Factory[] CyborgNumberSort(Factory[] inputFactoryList){
        Factory[] output = new Factory[inputFactoryList.Length];
        inputFactoryList.CopyTo(output, 0);
        
        int pointer1 = 0;
        int pointer2 = 1;
        if(output.Length == 1 || output.Length == 0){ return output; }
        if(output.Length == 2){
            if(output[pointer1].cyborgNumber < output[pointer2].cyborgNumber){
                Factory temp1 = output[pointer1];
                Factory temp2 = output[pointer2];

                output[pointer2] = temp1;
                output[pointer1] = temp2;
                
            }
            return output;
        }
        
        while(pointer1 <= output.Length-1){
            if(output[pointer1].cyborgNumber < output[pointer2].cyborgNumber){
                Factory temp = output[pointer2];

                for(int i = pointer2-1; i >= pointer1; i--){
                    output[i+1] = output[i];
                }
                output[pointer1] = temp;

            }

            pointer2++;
            if(pointer2 == output.Length){
                pointer2 = pointer1+2;
                pointer1 += 1;
                if(pointer2==output.Length){break;}
            }
            
        }
        return output;
    }
    /// <summary>The method <c>MostTargettedSort</c> takes an array of factories and sorts them (in descending order) of the most targetted.</summary>
    /// <param name='inputFactoryList'> The array of factories that you want to sort by descending most targetted.</param>
    public static Factory[] MostTargettedSort(Factory[] inputFactoryList){
        Factory[] output = new Factory[inputFactoryList.Length];
        inputFactoryList.CopyTo(output, 0);
        
        int pointer1 = 0;
        int pointer2 = 1;
        if(output.Length == 1 || output.Length == 0){ return output; }
        if(output.Length == 2){
            if(  CyborgNumberSum(TroopsTargetting(output[pointer1].entityID)) < CyborgNumberSum(TroopsTargetting(output[pointer2].entityID)) ){
                Factory temp1 = output[pointer1];
                Factory temp2 = output[pointer2];

                output[pointer2] = temp1;
                output[pointer1] = temp2;
                
            }
            return output;
        }
        
        while(pointer1 <= output.Length-1){
            if(CyborgNumberSum(TroopsTargetting(output[pointer1].entityID)) < CyborgNumberSum(TroopsTargetting(output[pointer2].entityID))){
                Factory temp = output[pointer2];

                for(int i = pointer2-1; i >= pointer1; i--){
                    output[i+1] = output[i];
                }
                output[pointer1] = temp;

            }

            pointer2++;
            if(pointer2 == output.Length){
                pointer2 = pointer1+2;
                pointer1 += 1;
                if(pointer2==output.Length){break;}
            }
            
        }
        return output;
    }
    // TODO : ADD documentation for this function.
    public static int CyborgNumberSum(Troop[] troopList){
        int output = 0; 
        for(int i = 0; i < troopList.Length; i++){  
            output += troopList[i].ownership*troopList[i].cyborgNumber;
        }
        return output;
    }
    /// <summary>The method <c>METRICSort</c> takes an array of factories and sorts them (in descending order) of the METRIC.</summary>
    /// <param name='factoryID'> The array of factories that you want to sort by descending METRIC.</param>
    /// <param name='inputFactoryList'> The array of factories that you want to sort by descending METRIC.</param>
    public static Factory[] METRICSort(int factoryID, Factory[] inputFactoryList){
        Factory[] output = new Factory[inputFactoryList.Length];
        inputFactoryList.CopyTo(output, 0);
        
        int pointer1 = 0;
        int pointer2 = 1;
        if(output.Length == 1 || output.Length == 0){ return output; }
        if(output.Length == 2){
            if(METRIC[factoryID,output[pointer1].entityID] < METRIC[factoryID,output[pointer2].entityID]){
                Factory temp1 = output[pointer1];
                Factory temp2 = output[pointer2];

                output[pointer2] = temp1;
                output[pointer1] = temp2;
                
            }
            return output;
        }
        
        while(pointer1 <= output.Length-1){
            if(METRIC[factoryID,output[pointer1].entityID] < METRIC[factoryID,output[pointer2].entityID]){
                Factory temp = output[pointer2];

                for(int i = pointer2-1; i >= pointer1; i--){
                    output[i+1] = output[i];
                }
                output[pointer1] = temp;

            }

            pointer2++;
            if(pointer2 == output.Length){
                pointer2 = pointer1+2;
                pointer1 += 1;
                if(pointer2==output.Length){break;}
            }
            
        }
        return output;
    }
    /// <summary> <c>DisplayFactoryData</c> takes an array of factories and prints their data into the error console. </summary>
    /// <param name="factoryList"><c>factoryList</c> is the array of factories that you want their data to be printed.</param>
    public static void DisplayFactoryData(Factory[] factoryList){
        if(factoryList.Length == 0) { Console.Error.WriteLine("No factories are in this array.");}
        for(int i = 0; i < factoryList.Length; i++){
            Console.Error.WriteLine((i+1) + "- entityID:" + factoryList[i].entityID + " ownership:" + factoryList[i].ownership + " cyborgNumber:" + factoryList[i].cyborgNumber + " productionRate:" + factoryList[i].productionRate);
        }
    }
    /// <summary> <c>DisplayTroopData</c> takes an array of troops and prints their data into the error console. </summary>
    /// <param name="troopList"><c>factoryList</c> is the array of troops that you want their data to be printed.</param>
    public static void DisplayTroopData(Troop[] troopList){
        if(troopList.Length == 0) { Console.Error.WriteLine("No Troops are in this array.");}
        for(int i = 0; i < troopList.Length; i++){
            Console.Error.WriteLine((i+1) + "- entityID:" + troopList[i].entityID + " ownership:" + troopList[i].ownership + " cyborgNumber:" + troopList[i].cyborgNumber + " sourceFactoryID:" + troopList[i].sourceFactoryID + " targetFactoryID:" + troopList[i].targetFactoryID + " eta:" + troopList[i].eta);
        }
    }
    // TODO: Make the "NumberOfTroopsToSend" also be able to suggest sending bombs.
    /// <summary>The function <c>NumberOfTroopsToSend</c> takes two parameters and outputs a value of how many troops to send to the target. It simulates the evolution of the game inside of the function under some assumptions. These assumptions can be updated and may get better with time however the functionality is not present and the approach is naive.</summary>
    /// <param name="sourceFactoryID"> is the ID of the factory that you want to send the troops from.</param>
    /// <param name="troopsTargetting"> is the ID of the factory that you want to send the troops to. </param>
    public static int NumberOfTroopsToSend(int sourceFactoryID, int targetFactoryID){
        Troop[] troopsTargetting = TroopsTargetting(targetFactoryID);
        Troop[] troopsTargettingSource = TroopsTargetting(sourceFactoryID);
        if(CyborgNumberSum(TroopsTargetting(sourceFactoryID)) <= 0){return 0;}
        int elapsedTime = 0;
        int maxTime = 0;
        for(int i = 0; i < troopsTargetting.Length; i++){
            if(troopsTargetting[i].eta > maxTime){ maxTime = troopsTargetting[i].eta; }
        }
        for(int i = 0; i < troopsTargettingSource.Length; i++){
            if(troopsTargettingSource[i].eta > maxTime){ maxTime = troopsTargettingSource[i].eta; }
        }
        
        int arg1 = currentFactories[targetFactoryID].ownership;
        int arg2 = currentFactories[targetFactoryID].cyborgNumber;
        int arg3 = currentFactories[targetFactoryID].productionRate;
        
        Factory targettedFactory = new Factory(targetFactoryID, arg1, arg2, arg3);

        arg1 = currentFactories[sourceFactoryID].ownership;
        arg2 = currentFactories[sourceFactoryID].cyborgNumber;
        arg3 = currentFactories[sourceFactoryID].productionRate;
        
        Factory sourceFactory = new Factory(sourceFactoryID, arg1, arg2, arg3);
        
        while(maxTime != elapsedTime){
            for(int i = 0; i < troopsTargetting.Length; i++){
                if(Math.Abs(troopsTargetting[i].eta) == elapsedTime){
                    if(targettedFactory.ownership == NEUTRAL && targettedFactory.cyborgNumber == 0){
                        targettedFactory.ownership = troopsTargetting[i].ownership;
                        targettedFactory.cyborgNumber = troopsTargetting[i].cyborgNumber;
                        
                    }
                    if(troopsTargetting[i].ownership == targettedFactory.ownership){
                        targettedFactory.cyborgNumber += troopsTargetting[i].cyborgNumber;
                    }
                    if(troopsTargetting[i].ownership != targettedFactory.ownership){
                        targettedFactory.cyborgNumber -= troopsTargetting[i].cyborgNumber;
                    }
                    
                    
                }
            }
            for(int i = 0; i < troopsTargettingSource.Length; i++){
                if(Math.Abs(troopsTargettingSource[i].eta) == elapsedTime){
                    if(troopsTargettingSource[i].ownership == sourceFactory.ownership){
                        sourceFactory.cyborgNumber += troopsTargettingSource[i].cyborgNumber;
                    }
                    if(troopsTargettingSource[i].ownership != sourceFactory.ownership){
                        sourceFactory.cyborgNumber -= troopsTargettingSource[i].cyborgNumber;
                    }
                    
                    
                }
            }
            
            if(targettedFactory.cyborgNumber < 0){
                targettedFactory.cyborgNumber *= -1;
                targettedFactory.ownership *= -1;
            }
            if(sourceFactory.cyborgNumber < 0){
                sourceFactory.cyborgNumber *= -1;
                sourceFactory.ownership *= -1;
            }
            sourceFactory.cyborgNumber += sourceFactory.productionRate;
            if(targettedFactory.ownership != NEUTRAL){targettedFactory.cyborgNumber += targettedFactory.productionRate;}
            
            elapsedTime++;
        }
        
        if(targettedFactory.cyborgNumber < 0){ targettedFactory.cyborgNumber *= -1; targettedFactory.ownership *= -1; }
        if(sourceFactory.cyborgNumber < 0){ sourceFactory.cyborgNumber *= -1; sourceFactory.ownership *= -1; }
        
        if(targettedFactory.ownership == PLAYER){return 0;}
        if(sourceFactory.ownership == ENEMY){return 0;}
        
        if(targettedFactory.ownership == ENEMY && sourceFactory.ownership == PLAYER){
            if(currentFactories[sourceFactoryID].cyborgNumber < targettedFactory.cyborgNumber + 1 +currentFactories[sourceFactoryID].productionRate*METRIC[sourceFactoryID,targetFactoryID]){
                if(currentFactories[sourceFactoryID].cyborgNumber <= targettedFactory.productionRate){return 0;}
                return currentFactories[sourceFactoryID].cyborgNumber-1;
            }
            
        }
        if(targettedFactory.ownership == NEUTRAL){
            return targettedFactory.cyborgNumber+1;
        }
        if(targettedFactory.cyborgNumber + 1 + currentFactories[sourceFactoryID].productionRate*METRIC[sourceFactoryID,targetFactoryID] <= targettedFactory.productionRate && targettedFactory.ownership != NEUTRAL){return 0;}
        return targettedFactory.cyborgNumber + 1 + currentFactories[sourceFactoryID].productionRate*METRIC[sourceFactoryID,targetFactoryID];
    }
    public static Troop[] TroopsTargetting(int ID){
        List<Troop> output = new List<Troop>();
        for(int i = 0; i < currentTroops.Length; i++){
            if(currentTroops[i] == null){break;}
            if(currentTroops[i].targetFactoryID == ID){ 
                output.Add(currentTroops[i]);
            }
        }
        return output.ToArray();
    }
    static void Main(string[] args)
    {
        string[] inputs;
        int maxDistance = 0;
        factoryCount = int.Parse(Console.ReadLine()); // the number of factories
        int linkCount = int.Parse(Console.ReadLine()); // the number of links between factories
        METRIC = new int[factoryCount, factoryCount];
        currentFactories = new Factory[factoryCount];
        for (int i = 0; i < linkCount; i++){
            inputs = Console.ReadLine().Split(' ');
            int factory1 = int.Parse(inputs[0]);
            int factory2 = int.Parse(inputs[1]);
            int distance = int.Parse(inputs[2]);
            if(distance > maxDistance){maxDistance = distance;}

            // Because the distance between two objects doesn't matter which way you put them in the matrix.
            METRIC[factory1,factory2] = distance;
            METRIC[factory2,factory1] = distance;
        }
        Console.Error.WriteLine(maxDistance);
        // game loop
        while (true)
        {
            entityCount = int.Parse(Console.ReadLine()); // the number of entities (e.g. factories and troops)
            

            List<Factory> playerFactoriesList = new List<Factory>();
            List<Factory> enemyFactoriesList = new List<Factory>();
            List<Factory> neutralFactoriesList = new List<Factory>();
            List<Factory> nonPlayerFactoriesList = new List<Factory>();

            List<Troop> playerTroopsList = new List<Troop>();
            List<Troop> enemyTroopsList = new List<Troop>();
            
            List<Bomb> playerBombsList = new List<Bomb>();
            List<Bomb> enemyBombsList = new List<Bomb>();

            List<Troop> currentTroopsList = new List<Troop>();
            List<Bomb> currentBombsList = new List<Bomb>();


            int troopCounter = 0; // A variable to make sure that the currentTroops array still has a proper order.
            
            for (int i = 0; i < entityCount; i++)
            {
                
                inputs = Console.ReadLine().Split(' ');
                int entityId = int.Parse(inputs[0]);
                string entityType = inputs[1];
                int arg1 = int.Parse(inputs[2]);
                int arg2 = int.Parse(inputs[3]);
                int arg3 = int.Parse(inputs[4]);
                int arg4 = int.Parse(inputs[5]);
                int arg5 = int.Parse(inputs[6]);
                // Debugging Line to determine what entities are being sent over:
                // Console.Error.WriteLine(entityType + " " + entityId);


                if(entityType == "FACTORY"){
                    currentFactories[entityId] = new Factory(entityId, arg1, arg2, arg3);
                    if(arg1 == PLAYER){ 
                        if(timeElapsed == 0){
                            armies = new Factory[1];
                            armies[0] = new Factory(entityId, arg1, arg2, arg3);
                            resources = new Factory[0];
                        }
                        playerFactoriesList.Add(new Factory(entityId, arg1, arg2, arg3));
                        
                    }
                    if(arg1 == ENEMY){ enemyFactoriesList.Add(new Factory(entityId, arg1, arg2, arg3)); }
                    if(arg1 == NEUTRAL){ neutralFactoriesList.Add(new Factory(entityId, arg1, arg2, arg3)); }
                    
                }
                if(entityType == "TROOP"){
                    currentTroopsList.Add(new Troop(entityId, arg1, arg2, arg3, arg4, arg5));
                    if(arg1 == PLAYER){ playerTroopsList.Add(new Troop(entityId, arg1, arg2, arg3, arg4, arg5));}
                    if(arg1 == ENEMY){ enemyTroopsList.Add(new Troop(entityId, arg1, arg2, arg3, arg4, arg5)); }
                }
                if(entityType == "BOMB"){
                    currentBombsList.Add(new Bomb(entityId, arg1, arg2, arg3, arg4));
                    if(arg1 == PLAYER){ playerBombsList.Add(new Bomb(entityId, arg1, arg2, arg3, arg4));}
                    if(arg1 == ENEMY){ enemyBombsList.Add(new Bomb(entityId, arg1, arg2, arg3, arg4)); }
                }


            }
            
            timeElapsed++;
            
            nonPlayerFactoriesList.AddRange(neutralFactoriesList);
            nonPlayerFactoriesList.AddRange(enemyFactoriesList);
            playerFactories = playerFactoriesList.ToArray();
            enemyFactories = enemyFactoriesList.ToArray();
            neutralFactories = neutralFactoriesList.ToArray();
            nonPlayerFactories = nonPlayerFactoriesList.ToArray();
            playerTroops = playerTroopsList.ToArray();
            enemyTroops = enemyTroopsList.ToArray();
            playerBombs = playerBombsList.ToArray();
            enemyBombs = enemyBombsList.ToArray();


            if(enemyBombs.Length == 1){
                if(enemyBombs[enemyBombs.Length-1].sourceFactoryID == enemyBombsList[enemyBombsList.Count-1].sourceFactoryID){
                    bombCount++;
                    shuffledArmies = false;
                }
            }
            currentBombs = currentBombsList.ToArray();
            currentTroops = currentTroopsList.ToArray();

            DisplayFactoryData(playerFactories);
            DisplayFactoryData(enemyFactories);
            Console.Error.WriteLine("WTF ISG OING ON!");
            DisplayFactoryData(armies);
            DisplayFactoryData(resources);
            
            Console.Error.WriteLine("WHAT IS GOING ON????");
            

            

            // This is where we decide on which actions to do:
            
            
            /*
            float choiceValue = ModeSelectionFunction();
            if(choiceValue > 0){ output = OffenseMode(); }
            if(choiceValue <= 0){
                float p = ProductionRateDefenseModeThreshold();
                if(choiceValue > p){ output = ProductionRateDefenseMode(); }
                else{ output = DefenseMode(); }
            }
            */

            List<Troop> output = OffenseMode().ToList();
            output.AddRange(DefenseMode().ToList());
            // DisplayTroopData(output);
            
            // This is what we will do when we have the functions all sorted out.
            ReturnOutput(output.ToArray());
        }
    }
}