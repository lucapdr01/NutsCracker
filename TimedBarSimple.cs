using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TimedBarSimple : MonoBehaviour {
    public float Maxhelath { get; set; }
    public float Currenthelath { get; set; }
    
    public GameObject SuperHandbt;

    public Slider healthBar;
    public Text MessageText;
    Animator MessageTextAnimator;

    bool canstart;

    int superHands;
    // Use this for initialization
    private void Awake()
    {
        canstart = false;
        Maxhelath = 20f;
        Currenthelath = Maxhelath * 0.3f;

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

       

       

        
    }

    public void BonusH(float bonus)
    {
        Currenthelath += bonus;
        healthBar.value = calculateHealth();
        MessageText.text = "Good Job!";
        StartCoroutine(MessageTextAnim());
        if (Currenthelath >= Maxhelath)
        {
            if (Manager.Instance.UsingsuperHand == false)
            {
                SuperHandbt.SetActive(true);
                Manager.Instance.UsingsuperHand = true;
                superHands++;
                Debug.Log("SuperHands" + superHands.ToString());
                 if (superHands >= 3 && GameManagment.Instance.stats.missionsCompleted[5] == false && SceneManager.GetActiveScene().buildIndex == 2)
                {
                    Debug.Log("Mission6 Completed");
                    GameManagment.Instance.stats.missionsCompleted[5] = true;
                    SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                    FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission3, FindObjectOfType<LevelMissionAnim>().Cup);

                }
            }
            MessageText.text = "Awsome!";
            StartCoroutine(MessageTextAnim());
            Currenthelath = 0.3f * Maxhelath;
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
