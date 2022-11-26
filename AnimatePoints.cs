using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePoints : MonoBehaviour {

    Animator animator;
	void Start () {

        animator = this.GetComponent<Animator>();
        StartCoroutine(Animate());
       
	}
	
	IEnumerator Animate()
    {
        
        animator.Play("success");
        yield return new WaitForSeconds(0.6f);
        Destroy(this.gameObject);
    }
}
