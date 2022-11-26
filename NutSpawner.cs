using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NutSpawner : MonoBehaviour {

    public GameObject[] Nuts;

    public Transform[] spawnpoints;

    bool Nspawning = true;
    
    int npoints;
    int nNuts;

    public float timetowait;

    bool isPasued;
    private void Awake()
    {
        npoints = spawnpoints.Length;
        nNuts = spawnpoints.Length;
       
    }
    void Start () {

        //  Debug.Log(elemnts.ToString());
        isPasued = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Nspawning)
        {
            isPasued = this.GetComponent<Manager>().isPaused;
            StartCoroutine(SpawnObjects());

        }
    }
    IEnumerator SpawnObjects()
    {
        if (!isPasued)
        {
            Instantiate(Nuts[Random.Range(0, nNuts - 2)], spawnpoints[Random.Range(0, npoints - 2)]);
            Nspawning = false;
            if (timetowait < 0.8f)
            {
                timetowait = 0.8f;
            }
            yield return new WaitForSeconds(timetowait);
            if(SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                StartCoroutine(DecreseTime());
            }
            Nspawning = true;
        }
    }
    IEnumerator DecreseTime()
    {
        timetowait = timetowait * (90 / 100);
        yield return new WaitForSeconds(5f);
    }
}
