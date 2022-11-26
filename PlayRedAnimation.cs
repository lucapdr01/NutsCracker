using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRedAnimation : MonoBehaviour {

    Animator animator;
    public bool touched = false;
  
    void Start()
    {

        animator = this.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (touched)
        {
            Debug.Log("Redtouch");
            StartCoroutine(Animate());
        }
    }
    IEnumerator Animate()
    {
        animator.SetBool("Touched", true);
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("Touched", false);
       
        Destroy(this.gameObject);
    }
}


