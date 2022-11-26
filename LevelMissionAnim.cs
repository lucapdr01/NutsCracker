using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMissionAnim : MonoBehaviour {

    public GameObject Cup;

    public GameObject Mission1;
    public GameObject Mission2;
    public GameObject Mission3;

    public GameObject LevelCanv;

    void Start () {
       
        //AnimateStar(Mission1,Cup);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
   public void AnimateStar(GameObject Star,GameObject Cup)
    {
        LevelCanv.SetActive(true);
        Manager.Instance.Pause();
        Manager.Instance.OptionCanvas.SetActive(false);
        StartCoroutine(AnimStars(Star,Cup));
    }
     IEnumerator AnimStars(GameObject Star,GameObject Cup)
    {

        Animator CupAnim = Cup.GetComponent<Animator>();
        Animator anim = Star.GetComponent<Animator>();
        Manager.Instance.OptionCanvas.SetActive(false);
        anim.SetBool("completed", true);
        CupAnim.SetBool("isAnim", true);
        FindObjectOfType<AudioManager>().PlaySound("Tada");
        // CheckForMissions();
        yield return new WaitForSeconds(1f);
        Star.GetComponentInChildren<Text>().color = Color.black;
        anim.SetBool("completed", true);
        CupAnim.SetBool("isAnim", false);
        yield return new WaitForSeconds(1f);
        Manager.Instance.OptionCanvas.SetActive(true);
        if (!GameManagment.Instance.isGameOver)
        {
            Manager.Instance.Play();
        }
        LevelCanv.SetActive(false);
    }  
    public void CheckForMissions()
    {
        Mission1.GetComponent<StarScript>().ChangeColor(Mission1);
        Mission2.GetComponent<StarScript>().ChangeColor(Mission2);
        Mission3.GetComponent<StarScript>().ChangeColor(Mission3);
    }
}
