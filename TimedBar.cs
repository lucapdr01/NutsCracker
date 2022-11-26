using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimedBar : MonoBehaviour {
    public float Maxhelath { get; set; }
    public float Currenthelath { get; set; }
    public float descresPerSecond;
    public GameObject SuperHandbt;

    public int superHands;

    public Slider healthBar;
    public Text MessageText;
    Animator MessageTextAnimator;

    bool canstart;
    // Use this for initialization
    private void Awake()
    {
        canstart = false;
        Maxhelath = 20f;
        Currenthelath = Maxhelath * 0.65f;

        healthBar.value = calculateHealth();
        Debug.Log(healthBar.value.ToString());
        MessageTextAnimator = MessageText.GetComponent<Animator>();
        

    }

    void Start ()
    {
        
            healthBar.gameObject.SetActive(true);
            canstart = true;

        superHands = 0;
        
    }
	
	// Update is called once per frame
	void Update () {

       

       

        if (canstart) { DecreseH(); }   
    }
    void DecreseH()
    {
        if (!Manager.Instance.isPaused)
        {
            Currenthelath -= Time.deltaTime * descresPerSecond;
            healthBar.value = calculateHealth();
            if (Currenthelath <= 0)
            {
                FindObjectOfType<HeartsBar>().lifelost = true;
                MessageText.text = "Bad";
                StartCoroutine(MessageTextAnim());
                Currenthelath = Maxhelath;
                healthBar.value = calculateHealth();

            }
        }
    }
    public void BonusH(float bonus)
    {
        Currenthelath += bonus;
        healthBar.value = calculateHealth();
        MessageText.text = "Good Job!";
        StartCoroutine(MessageTextAnim());
        if (Currenthelath >= Maxhelath)
        {
            if (!Manager.Instance.UsingsuperHand == true)
            {
                SuperHandbt.SetActive(true);
                superHands++;
                descresPerSecond *= 1.05f;
                FindObjectOfType<NutSpawner>().timetowait -= 0.1f;
                Debug.Log("SuperHands" + superHands.ToString());
                if (superHands >= 10 && GameManagment.Instance.stats.missionsCompleted[7] == false && SceneManager.GetActiveScene().buildIndex == 3)
                {
                    Debug.Log("Mission 8 Completed");
                    GameManagment.Instance.stats.missionsCompleted[7] = true;
                    SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                    FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission2, FindObjectOfType<LevelMissionAnim>().Cup);
                    
                }

            }
            MessageText.text = "Awsome!";
            StartCoroutine(MessageTextAnim());
            Currenthelath = 0.65f * Maxhelath;
            Manager.Instance.UsingsuperHand = false;
        }
        Manager.Instance.UsingsuperHand = false;
    }
    float calculateHealth()
    {
        return Currenthelath / Maxhelath;
    }
  IEnumerator MessageTextAnim()
    {
        MessageTextAnimator.SetBool("isAnimating", true);
        yield return new WaitForSeconds(0.01f);
        MessageTextAnimator.SetBool("isAnimating", false);
    }

}
