using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject cut;
    public GameObject Hand;
    public bool isCameraPaused;
	void Start () {
        isCameraPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isCameraPaused)
        {
            instantiator();
        }
	}
    private void instantiator()
    {
        Debug.Log("Input");
        Vector3 point = new Vector3();
     

        point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Camera.main.nearClipPlane));
        point.y = 1f;


        Instantiate(Hand,new Vector3(point.x,point.y + 2,point.z), Hand.transform.rotation);
        
        //Instantiate(cut,point,cut.transform.rotation);
    }
}
