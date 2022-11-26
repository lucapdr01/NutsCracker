using System;

[Serializable]
public class Stats
{

    public ulong bestScore;
    public ulong levelNumber;
    public String[] missions;
    public bool[] missionsCompleted;
    public ulong goldNutsNumber;
    public ulong deathsNumber;
    public ulong greenHands;

    public Stats(ulong bestScore, ulong levelNumber,String[] missions,bool[] missionsCompleted,ulong goldNutsNumber,ulong deathsNumber,ulong greenHands)
    {
        this.bestScore = bestScore;
        this.levelNumber = levelNumber;
        this.missions = missions;
        this.missionsCompleted = missionsCompleted;
        this.goldNutsNumber = goldNutsNumber;
        this.deathsNumber = deathsNumber;
        this.greenHands = greenHands;
       
    }

}