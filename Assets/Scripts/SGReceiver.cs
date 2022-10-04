using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGReceiver : MonoBehaviour
{
    public char type;
    public char situation;
    public int channel;
    public bool isFinishReceiver;

    private Color color;
    void Start()
    {
        this.gameObject.GetComponentInChildren<TextMesh>().text = situation.ToString();

        switch (type)
        {
            case ('x'):
                if (ColorUtility.TryParseHtmlString("#FE175B", out color))
                { this.gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;

            case ('y'):
                if (ColorUtility.TryParseHtmlString("#00DCFF", out color))
                { this.gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;

            case ('z'):
                if (ColorUtility.TryParseHtmlString("#00FF73", out color))
                { this.gameObject.GetComponent<SpriteRenderer>().color = color; }
                break;
        }


    }

    public void DetectLaser(Transform source, Transform laser)
    {
        if (source.tag == "Source")
        {
            if (source.GetComponent<SGSource>().getType().Equals(type))
            {
                if (laser.name == situation.ToString())
                {
                    StartAction();
                }                
            }
        }
    }

    void StartAction()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
        for(int i = 0; i < doors.Length; i++)
        {
            if (doors[i].GetComponent<SGDoor>().getChannel() == channel)
            {
                doors[i].GetComponent<SGDoor>().Open();
            }
        }
    }
}
