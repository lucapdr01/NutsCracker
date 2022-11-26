using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour {
    // public GameObject point;
    private void Start()
    {
        StartCoroutine(WaitanIstant());
        GameManagment.Instance.isGameOver = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if (other.gameObject.CompareTag("Target"))
        {
          //  FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission2, FindObjectOfType<LevelMissionAnim>().Cup);


            other.GetComponent<PlayNutDestruction>().distructed = true;
           // Destroy(other.gameObject);
            //call increase score
           // Instantiate(point, this.transform.position, point.transform.rotation);
            Manager.Instance.Score(5);
            if (FindObjectOfType<TimedBar>()!= null)
            {
                FindObjectOfType<TimedBar>().BonusH(2f);
            }
            if (FindObjectOfType<TimedBarSimple>() != null)
            {
                FindObjectOfType<TimedBarSimple>().BonusH(1f);
            }
            FindObjectOfType<AudioManager>().PlaySound("Punto");

        }
        else if (other.gameObject.CompareTag("Bonus"))
        {
           
            other.GetComponent<PlayNutDestruction>().distructed = true;
            Manager.Instance.Score(25);
            if (FindObjectOfType<TimedBar>() != null)
            {
                FindObjectOfType<TimedBar>().BonusH(5f);
            }
            if (FindObjectOfType<TimedBarSimple>() != null)
            {
                FindObjectOfType<TimedBarSimple>().BonusH(5f);
            }
            FindObjectOfType<AudioManager>().PlaySound("Point");
            GameManagment.Instance.stats.goldNutsNumber++;
            if (GameManagment.Instance.stats.goldNutsNumber >= 25 && GameManagment.Instance.stats.missionsCompleted[8] == false && SceneManager.GetActiveScene().buildIndex == 3)
            {
                Debug.Log("Mission9 Completed");
                GameManagment.Instance.stats.missionsCompleted[8] = true;
                SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission3, FindObjectOfType<LevelMissionAnim>().Cup);

            }
            else if (GameManagment.Instance.stats.goldNutsNumber >= 9 && GameManagment.Instance.stats.missionsCompleted[4] == false && SceneManager.GetActiveScene().buildIndex == 2)
            {
                Debug.Log("Mission5 Completed");
                GameManagment.Instance.stats.missionsCompleted[4] = true;
                SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission2, FindObjectOfType<LevelMissionAnim>().Cup);

            }
            else if (GameManagment.Instance.stats.goldNutsNumber >= 3 && GameManagment.Instance.stats.missionsCompleted[0] == false)
            {
                Debug.Log("Mission1 Completed");
                GameManagment.Instance.stats.missionsCompleted[0] = true;
                SaveAndLoadManager.Instance.save(GameManagment.Instance.stats);
                FindObjectOfType<LevelMissionAnim>().AnimateStar(FindObjectOfType<LevelMissionAnim>().Mission1, FindObjectOfType<LevelMissionAnim>().Cup);

            }
        }
        else if (other.gameObject.CompareTag("Error"))
        {
            other.GetComponent<PlayRedAnimation>().touched = true;
            if (!this.gameObject.CompareTag("SuperHand"))
            {
                FindObjectOfType<HeartsBar>().lifelost = true;
                FindObjectOfType<AudioManager>().PlaySound("Errore");
            }
        }

    }
    IEnumerator WaitanIstant()
    {
        yield return new WaitForSeconds(1.1f);
        
        Destroy(transform.parent.gameObject);

    }
   
}
