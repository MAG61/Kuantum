using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneObjects : MonoBehaviour
{
    public GameObject[] objects;
    void Update()
    {
        if (SceneManager.sceneCount <= 1)
        {
            foreach (GameObject ob in objects)
            {
                ob.SetActive(true);
            }
        }
        else if (SceneManager.sceneCount > 1)
        {
            foreach (GameObject ob in objects)
            {
                ob.SetActive(false);
            }
        }
    }
}
