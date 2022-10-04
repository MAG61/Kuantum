using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappTubeController : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        StartCoroutine(destroy());
    }
    void FixedUpdate()
    {
        transform.position += Vector3.left * speed; 
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(10);
        GameObject.Destroy(gameObject);
    }
}
