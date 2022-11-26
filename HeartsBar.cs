using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsBar : MonoBehaviour{
    public bool lifelost;
    public List<GameObject> Hearts;

    int lifes;
    private Animator HeartAnimator;
   
    void Start () {
        lifelost = false;
        lifes = Hearts.Count;
        print(lifes);
        Debug.Log(lifes);
	}

    // Update is called once per frame
    void Update()
    {

        if (lifelost)
        {
            Debug.Log("lostlife");
            HeartAnimator = Hearts[0].GetComponentInChildren<Animator>();
           
            if (lifes > 0)
            {
                StartCoroutine(LifeAnim());
                lifes--;
            }
            
           
            lifelost = false;

        }
        if (lifes <= 0)
        {
            
            Manager.Instance.GameOver();
            GameManagment.Instance.stats.deathsNumber += 1;
            Debug.Log(GameManagment.Instance.stats.deathsNumber.ToString());
            SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
            if (GameManagment.Instance.stats.deathsNumber >= 3 && GameManagment.Instance.stats.missionsCompleted[2] == false)
            {
                Debug.Log("Mission3 Completed");
                GameManagment.Instance.stats.missionsCompleted[2] = true;
                SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission3, FindObjectOfType<LevelMissionAnim>().Cup);
            }
            Manager.Instance.GameOver();
            // lifes = 3;
            lifes = 1;
            lifelost = false;
        }
    }
    IEnumerator LifeAnim()
    {
        HeartAnimator.SetBool("LifeLost", true);
        yield return new WaitForSeconds(1f);
        HeartAnimator.SetBool("LifeLost", false);
        yield return new WaitForSeconds(1f);
        Destroy(Hearts[0]);
        Hearts.RemoveAt(0);
    }
}
