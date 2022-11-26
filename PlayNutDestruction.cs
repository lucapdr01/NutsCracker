using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNutDestruction : MonoBehaviour {
    Animator animator;
    public bool distructed = false;
   public  GameObject point;
    void Start()
    {

        animator = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        if (distructed)
        {
            Debug.Log("destruct");
            StartCoroutine(Animate());
        }
	}
    IEnumerator Animate()
    {
        animator.SetBool("destroyed", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("destroyed", false);
        Instantiate(point, this.transform.position, point.transform.rotation);
        Destroy(this.gameObject);
    }
}
