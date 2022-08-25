using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstantiateControl : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    private float randomFloat;
    
    private Vector3 defaultPosition = new Vector3(0, 0.91f, 0);

    public GameObject SpawnObjectsRandomly()
    {
        Debug.Log("Called the Spawn");
        randomFloat = Random.Range(0, 1f);
        Debug.Log(randomFloat);
        
        if (randomFloat <= 0.33)
        {
            return Instantiate(objects[0], defaultPosition, Quaternion.identity);
        }
        else if (randomFloat > 0.33f && randomFloat <= 0.66f)
        {
            return Instantiate(objects[1], defaultPosition, Quaternion.identity);
        }
        else
        {
            return Instantiate(objects[2], defaultPosition, Quaternion.identity);
        }

    }
}
