using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SGGameManager : MonoBehaviour
{

    public void Finish()
    {
        GameObject.Find("einstein").GetComponent<Animator>().SetTrigger("finish");
        GameObject.Find("Camera").GetComponent<Animator>().SetTrigger("finish");
        StartCoroutine(loadScene());
    }

    IEnumerator loadScene()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
