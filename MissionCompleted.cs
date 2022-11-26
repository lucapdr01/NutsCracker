using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCompleted : MonoBehaviour {

    public Animator anim;
	void Start () {
        this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void goalMade()
    {
        anim.SetBool("completed", true);
    }
}
