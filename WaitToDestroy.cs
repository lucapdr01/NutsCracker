using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitToDestroy : MonoBehaviour {

    public float time;
	void Start () {
        StartCoroutine(Wait(time));
	}
	IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);

    }
}
