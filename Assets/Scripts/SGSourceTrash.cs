using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGSourceTrash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Source")
        {
            Destroy(collision.gameObject);
        }
    }
}
