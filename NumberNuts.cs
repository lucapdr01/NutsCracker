using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NumberNuts : MonoBehaviour {

    public Text TooManyNutsText;
    private GameObject[] nuts;
    private GameObject[] bonus;
    private GameObject[] error;
    int maxnumber;
    void Start () {
        maxnumber = 10 - 1 * (SceneManager.GetActiveScene().buildIndex);
	}
	
	// Update is called once per frame
	void Update () {
        nuts = GameObject.FindGameObjectsWithTag("Target");
        bonus= GameObject.FindGameObjectsWithTag("Bonus");
        error = GameObject.FindGameObjectsWithTag("Error");
    
        if ((nuts.Length + bonus.Length + error.Length) > maxnumber)
        {
            StartCoroutine(TomanyNuts());

        }
	}
    IEnumerator TomanyNuts()
    {
        TooManyNutsText.gameObject.SetActive(true);
        Debug.Log("Too Many Nuts");
        yield return new WaitForSeconds(2f);
        Manager.Instance.GameOver();
    }
}
