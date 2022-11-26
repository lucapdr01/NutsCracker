using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : Singleton<GameManagment> {

   

    //Game Managment
    public delegate void Interacion();
    public Stats stats;
    public event Interacion firstStart;
    public bool isGameOver;
   
    private void Awake()
    {
        OnReload();
        isGameOver = false;
    }
    public void load()
    {
        if (SaveAndLoadManager.Instance.needFirstSave())
        {
            stats = SaveAndLoadManager.Instance.firstSave();

            if (firstStart != null)
            {
                firstStart();
               
            }
        }
        else
        {
            stats = SaveAndLoadManager.Instance.load();
        }

    }
    private void restartGame()
    {
        SaveAndLoadManager.Instance.removeSave();
        stats = SaveAndLoadManager.Instance.firstSave();
        if (firstStart != null)
        {
            firstStart();
        }

    }
    public void gameOver()
    {
        isGameOver = true;
        CheckForScore();

    }
    public ulong bestScore()
    {
        return GameManagment.Instance.stats.bestScore;
    }
    public ulong LevelNumber()
    {
        return GameManagment.Instance.stats.levelNumber;
    }
    public String[] myMissions()
    {
        return GameManagment.Instance.stats.missions;
    }
    void CheckForScore()
    {
        ulong bestscore = GameManagment.Instance.stats.bestScore;
        if ((ulong)Manager.Instance.score > bestscore)
        {
            stats.bestScore = (ulong)Manager.Instance.score;
            SaveAndLoadManager.Instance.save(stats);
            Debug.Log("NewBestScore");
            Manager.Instance.NewBestScore.gameObject.SetActive(true);
           
        }
        if (stats.bestScore >= 2500 && stats.missionsCompleted[6] == false && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Mission7 Completed");
            stats.missionsCompleted[6] = true;
            SaveAndLoadManager.Instance.save(stats);
            FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission1, FindObjectOfType<LevelMissionAnim>().Cup);

        }
        else if (stats.bestScore >= 600 && stats.missionsCompleted[3] == false &&  SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Mission4 Completed");
            stats.missionsCompleted[3] = true;
            SaveAndLoadManager.Instance.save(stats);
            FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission1, FindObjectOfType<LevelMissionAnim>().Cup);

        }
        else if (stats.bestScore >= 300 && stats.missionsCompleted[1] == false)
        {
            Debug.Log("Mission2 Completed");
            stats.missionsCompleted[1] = true;
            SaveAndLoadManager.Instance.save(stats);
            //
            FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission2, FindObjectOfType<LevelMissionAnim>().Cup);

        }
    }
}
