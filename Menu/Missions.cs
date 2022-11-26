using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Missions : MonoBehaviour {

    private String[] missions;
    private bool[] missionsComplet;
    int level;
   public  Text levelText;
    public Text Mission1Text;
    public Text Mission2Text;
    public Text Mission3Text;
    public Sprite compeltedStar;

    private bool mission1Bool;
    private bool mission2Bool;
    private bool mission3Bool;

    void Start () {        

    }
	
	// Update is called once per frame
	void Update () {
        if (FindObjectOfType<MenuManger>().loaded)
        {
            getValues();
            FindObjectOfType<MenuManger>().loaded = false;
            print(GameManagment.Instance.LevelNumber().ToString());
        }
        
    }
    void getValues()
    {
        level =(int)GameManagment.Instance.LevelNumber() +1 ;
        levelText.text = "LEVEL " + level.ToString();
        missions = GameManagment.Instance.myMissions();
        missionsComplet = GameManagment.Instance.stats.missionsCompleted;
       if(level == 1)
        {
            Mission1Text.text = missions[0];
            Mission2Text.text = missions[1];
            Mission3Text.text = missions[2];

            mission1Bool = missionsComplet[0];
            mission2Bool = missionsComplet[1];
            mission3Bool = missionsComplet[2];
            if (mission1Bool && mission2Bool && mission3Bool)
            {
                level = 2;
                GameManagment.Instance.stats.levelNumber = 1;
                levelText.text = "LEVEL " + level.ToString();

            }

           

        }
       if (level == 2)
        {
            Mission1Text.text = missions[3];
            Mission2Text.text = missions[4];
            Mission3Text.text = missions[5];

            mission1Bool = missionsComplet[3];
            mission2Bool = missionsComplet[4];
            mission3Bool = missionsComplet[5];
            if (mission1Bool && mission2Bool && mission3Bool)
            {
                level = 3;
                GameManagment.Instance.stats.levelNumber = 2;
                levelText.text = "LEVEL " + level.ToString();
            }
        }
       if (level == 3)
        {
            Mission1Text.text = missions[6];
            Mission2Text.text = missions[7];
            Mission3Text.text = missions[8];

            mission1Bool = missionsComplet[6];
            mission2Bool = missionsComplet[7];
            mission3Bool = missionsComplet[8];
        }
        //--------
        if (mission1Bool)
        {
            Mission1Text.color = Color.black;
            Mission1Text.gameObject.GetComponentInParent<Image>().sprite = compeltedStar;
        }
        if (mission2Bool)
        {
            Mission2Text.color = Color.black;
            Mission2Text.gameObject.GetComponentInParent<Image>().sprite = compeltedStar;

        }
       if (mission3Bool)
        {
            Mission3Text.color = Color.black;
            Mission3Text.gameObject.GetComponentInParent<Image>().sprite = compeltedStar;

        }



        // Debug.Log(missions.ToString());
        // Debug.Log(mission1 + " " + mission2 + " " + mission3);
    }
}
