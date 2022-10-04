using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    public float minX, maxX, minZ, maxZ, height;
    public List<GameObject> assets;
    public int numberOfObjects;
    public float objectDistance;

    public List<Transform> spawnedObjects;

    float randomX, randomZ;
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            while (spawnedObjects == null || spawnedObjects.Count != i+1)
            {
                randomX = Random.Range(minX, maxX);
                randomZ = Random.Range(minZ, maxZ);

                if (canSpawn(randomX, randomZ))
                {
                    GameObject randomAsset = assets[Random.Range(0, assets.Count)];
                    GameObject randomObject = GameObject.Instantiate(randomAsset, new Vector3(randomX, height, randomZ), Quaternion.Euler(0, 0, 0));

                    spawnedObjects.Add(randomObject.transform);
                }
            }
        }
    }

    public bool canSpawn(float x, float z)
    {
        if (spawnedObjects != null)
        {
            Debug.Log("if");
            for (int i = 0; i < spawnedObjects.Count; i++)
            {
                Debug.Log("for");
                if (spawnedObjects[i].transform.position.x - x < objectDistance && spawnedObjects[i].transform.position.x - x > -1 * objectDistance)
                {
                    Debug.Log("false1");
                    return false;
                }
                if (spawnedObjects[i].transform.position.z - z < objectDistance && spawnedObjects[i].transform.position.z - z > -1 * objectDistance)
                {
                    Debug.Log("false2");
                    return false;
                }
            }
        }

        return true;
    }

    void Update()
    {
        
    }
}
