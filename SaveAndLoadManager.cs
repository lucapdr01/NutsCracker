using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
//using Utils;

public class SaveAndLoadManager : Singleton<SaveAndLoadManager>
{

    private const string DATAPATH = "Stats.NutsCrackerBeta4";
    private Stats stats;
    private String[] goals = new string[] { "Crack 3 gold nuts", "Reach the socore of 300", "Die three times", "Reach the socore of 600", "Crack 9 gold nuts", "Use 3 times in the same match the super hand" , "Reach the score of 2500", "Use 10 times in the same match the super hand", "Crack 25 gold nuts" };
    private bool[] missionsCompl = new bool[] { false, false, false, false, false, false,false,false,false };
    private ulong goldNutsn = 0;
    private ulong deathsn = 0;
    private ulong greenHn = 0;
    private void Awake()
    {
        OnReload();
    }
    public string getDataPath()
    {
        return Path.Combine(Application.persistentDataPath, DATAPATH);

    }

    public bool needFirstSave()
    {
        return !File.Exists(getDataPath());
    }

    public void removeSave()
    {
        File.Delete(getDataPath());
    }

    public Stats firstSave()
    {
        if (needFirstSave())
        {
            Stats stats = new Stats(0,0,goals,missionsCompl,goldNutsn,deathsn,greenHn);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(getDataPath());
            binaryFormatter.Serialize(file, stats);
            file.Close();
            Debug.Log("First_Start");
            Debug.Log(stats.missions[0]);
            return stats;
            

        }
        return null;
    }
    public void save(Stats stats)
    {
        if (!needFirstSave())
        {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(getDataPath());
            binaryFormatter.Serialize(file, stats);
            file.Close();
        }
    }

    public Stats load()
    {

        if (!needFirstSave())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(getDataPath(), FileMode.Open);
            stats = (Stats)binaryFormatter.Deserialize(file);
            Debug.Log(stats.missions[0]);
            file.Close();

            return stats;
        }

        return null;
    }
}
