using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : Singleton<Manager> {

    
    public Text scoreText;
    
    public int score;
    public bool isPaused;

    public GameObject OptionCanvas;
    public GameObject Playbt;
    public GameObject Pausebt;
    public GameObject Exitbt;
    public GameObject Restartbt;
    public GameObject SuperHandbt;
    public GameObject NextLevelbt;

    public GameObject SuprHand;
    public bool UsingsuperHand;


    //Health system
   

    //GameManagment

    public GameObject FirstStartPanel;
    public Text NewBestScore;

    public bool ManagerLoaded;

   

    private void Awake()
    {
        
        OnReload();
        ManagerLoaded = false;
    }
    private void Start()
    {
        Debug.Log("app started");
        Debug.Log(Application.persistentDataPath);
       
     

        GameManagment.Instance.load();
        
       
       
        UsingsuperHand = false;
        isPaused = false;
        NewBestScore.gameObject.SetActive(false);
        ManagerLoaded = true;
        
    }
    private void Update()
    {
        //StartCoroutine(DecreseBar());

        
    }
   
   
    
    public void Score(int amaunt)
    {
        
        score += amaunt;
        scoreText.text =  score.ToString();
    }


    public void Pause()
    {
        //disattiva oggetti in scena
        isPaused = true;
        Restartbt.SetActive(false);
        SetBools(true);
       


    }
    public void Play()
    {
        isPaused = false;
        SetBools(false);
        
    }
    public void Exit()
    {
        //Application.Quit()
        //FindObjectOfType<PlayAds>().ShowAd();
        SceneManager.LoadScene(0);

    }
    public void Restart()
    {

        AudioManager.instance.adsCount++;

        if (AudioManager.instance.adsCount >= 5)
        {
           // FindObjectOfType<PlayAds>().ShowAd();
            AudioManager.instance.adsCount = 0;
        }
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void SetBools(bool val)
    {
        OptionCanvas.SetActive(val);
        Playbt.SetActive(val);
        Exitbt.SetActive(val);
        Pausebt.SetActive(!val);
        this.GetComponent<CameraController>().isCameraPaused = val;
    }
    public void NextLevl()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(level + 1);
    }
    public void GameOver()
    {
        StartCoroutine(Die());

        
    }
    IEnumerator Die()
    {
        isPaused = true;
        
        FindObjectOfType<AudioManager>().PlaySound("GameOver");
        Debug.Log("Gameover");
        SetBools(true);
        Playbt.SetActive(false);
        Restartbt.SetActive(true);
        GameManagment.Instance.gameOver();
        yield return new WaitForEndOfFrame();
        CheckForMissions();
    }
   

    public void SueprHand()
    {
        Instantiate(SuprHand);
        SuperHandbt.SetActive(false);
        UsingsuperHand = true;
    }
   
    void CheckForMissions()
    {
        int level =SceneManager.GetActiveScene().buildIndex;
        print("CurrentLevel:" + level.ToString());

        if(level == 1)
        {
            if(GameManagment.Instance.stats.missionsCompleted[0] && GameManagment.Instance.stats.missionsCompleted[1] && GameManagment.Instance.stats.missionsCompleted[2])
            {
                print("Level 1 Passed");
                Restartbt.SetActive(false);
                NextLevelbt.SetActive(true);
                
            }
        }
        if (level == 2)
        {
            if (GameManagment.Instance.stats.missionsCompleted[3] && GameManagment.Instance.stats.missionsCompleted[4] && GameManagment.Instance.stats.missionsCompleted[5])
            {
                print("Level 2 Passed");
                Restartbt.SetActive(false);
                NextLevelbt.SetActive(true);
            }
        }
        if (level == 3)
        {
            if (GameManagment.Instance.stats.missionsCompleted[6] && GameManagment.Instance.stats.missionsCompleted[7] && GameManagment.Instance.stats.missionsCompleted[8])
            {
                print("Level 3 Passed");
            }
        }
    }
}
