using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy manager = null;

    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (this != manager)
        {
            Destroy(gameObject);
        }
    }
}
