using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappSpawner : MonoBehaviour
{

    public float timer;
    void Start()
    {
        StartCoroutine(spawn(timer));
    }

    IEnumerator spawn(float timer)
    {
        yield return new WaitForSeconds(timer);

        Instantiate(Resources.Load("FlappTubes"), new Vector3(transform.position.x, Random.Range(-8,15), transform.position.z), this.transform.rotation);

        StartCoroutine(spawn(timer));
    }
}
