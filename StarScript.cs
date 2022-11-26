using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScript : MonoBehaviour
{

    public bool completed;
    public int number;
    public Sprite s;


    public void ChangeColor(GameObject Starob)
    {
        if (GameManagment.Instance.stats.missionsCompleted[number] == true)
        {

            Starob.GetComponent<Image>().sprite = s;
            Starob.GetComponentInChildren<Text>().color = Color.black;
        }
    }
}
