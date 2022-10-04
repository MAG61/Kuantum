using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public bool isSolved;
    public Vector3 mainPos;
    public Vector3 targetPos;
    public float damping;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSolved && transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, damping);
        }
        else if (!isSolved && transform.position != mainPos)
        {
            transform.position = Vector3.Lerp(transform.position, mainPos, damping);
        }
    }

    public void Launch()
    {

    }
}
