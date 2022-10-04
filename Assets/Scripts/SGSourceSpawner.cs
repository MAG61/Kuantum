using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGSourceSpawner : MonoBehaviour
{
    public char type;
    bool spawn = true;

    private void OnMouseDown()
    {
        if (spawn)
        {
            Instantiate(Resources.Load("SGSource"), new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), this.transform.rotation);
            this.spawn = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.spawn = false;
        if (collision.transform.tag == "Source")
        {
            collision.GetComponent<SGSource>().setType(this.type);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.spawn = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        this.spawn = false;
        if (other.transform.tag == "Source" && other.transform.GetComponent<SGSource>().type != this.type)
        {  
            other.GetComponent<SGSource>().setType(this.type);
        }
    }
}
