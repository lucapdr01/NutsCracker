using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManger : Singleton<MenuManger> {
    
    public Text bestScoreText;
    public bool loaded;

    //FirstStart
    public GameObject Panel;
    public Text t1;
    public Text t2;
    public Text t3;

    public Image im2;
    public Image im3;
    private void Awake()
    {
        OnReload();
        loaded = false;
    }
    void Start () {

        GameManagment.Instance.firstStart += NiceToMeetYou;

        GameManagment.Instance.load();
        loaded = true;
        bestScoreText.text = GameManagment.Instance.bestScore().ToString();
        Debug.Log(GameManagment.Instance.bestScore());
	}
	
	public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene((int)GameManagment.Instance.LevelNumber() +1);
    }
    public void AQuit()
    {
        Application.Quit();
    }
    //-------------- Game Managment--------------//
    private void NiceToMeetYou()
    {
        Debug.Log("NiceToMeetYou");
        StartCoroutine(NiceTMett());
        //FirstStartPanel.SetActive(true);
    }
    IEnumerator NiceTMett()
    {
        Panel.SetActive(true);
        t1.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        t2.gameObject.SetActive(true);
        im2.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        im2.gameObject.SetActive(false);
        t3.gameObject.SetActive(true);
        im3.gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        im3.gameObject.SetActive(false);
        Panel.SetActive(false);

    }
}
