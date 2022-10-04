using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    PlatformerGameManager manager;

    public GameObject text;

    public GameObject redLight;
    public GameObject greenLight;
    public GameObject interactObject;

    public bool isSolved;

    private bool isTouching = false;

    //private static Puzzle puzz = null;

    //private void Awake()
    //{
    //    if (puzz == null)
    //    {
    //        puzz = this;
    //        DontDestroyOnLoad(this);
    //    }
    //    else if (this != puzz)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<PlatformerGameManager>();
    }
    private void Update()
    {
        if (manager.getState(gameObject) == 1)
        {
            interactObject.GetComponent<InteractObject>().isSolved = true;
            isSolved = true;
        }
        else if (manager.getState(gameObject) == 0)
        {
            interactObject.GetComponent<InteractObject>().isSolved = false;
            isSolved = false;
        }

        if (isTouching  && Input.GetKeyDown(KeyCode.E))
        {
            manager.openPuzzle(gameObject);   
        }

        if (isSolved)
        {
            redLight.SetActive(false);
            greenLight.SetActive(true);
        }
        else
        {
            redLight.SetActive(true);
            greenLight.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            text.SetActive(true);
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            text.SetActive(false);
            isTouching = false;
        }
    }

    public void setState(bool state)
    {
        isSolved = state;
    }

}
