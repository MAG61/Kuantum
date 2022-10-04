using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGDoor : MonoBehaviour
{
    public int channel;
    Animator anim;

    public bool isFinishDoor = false;
    public bool isOpen;

    public Transform puzzleStarter;

    private Color color;

    PlatformerGameManager manager;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        manager = GameObject.Find("GameManager").GetComponent<PlatformerGameManager>();
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(manager.getIndex(manager.currentPuzzle) + 1));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isFinishDoor && !isOpen)
            {
                manager.setState(manager.currentPuzzleIndex, 0);
            }
            else if (isFinishDoor && isOpen)
            {
                manager.setState(manager.currentPuzzleIndex, 1);
            }
            manager.returnPlatformer();
        }

        if (isOpen)
        {
            if (ColorUtility.TryParseHtmlString("#6F7446", out color))
            { this.gameObject.GetComponent<SpriteRenderer>().color = color; }

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            if (ColorUtility.TryParseHtmlString("#FFFF00", out color))
            { this.gameObject.GetComponent<SpriteRenderer>().color = color; }
        }
        isOpen = false;
    }

    public int getChannel() { return this.channel; }
    public void Open()
    {
            //GameObject.Find("SGGameManager").GetComponent<SGGameManager>().Finish();
        isOpen = true;

        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        yield return new WaitForEndOfFrame();

    }
}
