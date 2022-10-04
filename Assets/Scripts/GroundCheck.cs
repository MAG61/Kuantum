using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    bool Touching;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {
            Touching = true;
        }
        else
        {
            Touching = false;
        }
    }

    public bool isTouching() { return Touching; }
}
