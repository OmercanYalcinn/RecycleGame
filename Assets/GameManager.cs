using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private bool _isObjectsListNull;

    [SerializeField] private float duration = 6f;
    
    [SerializeField] private List<GameObject> _objects;
    
    [SerializeField] private GameObject instantiateManager;
    [SerializeField] private GameObject temp;

    private void Start()
    {
        _objects = new List<GameObject>();
        _isObjectsListNull = _objects == null;
        InvokeRepeating("CheckTheStartButton", 1,2);
    }

    void CheckTheStartButton()
    {
        Debug.Log("Pressed the SPACE");
        temp = instantiateManager.GetComponent<InstantiateControl>().SpawnObjectsRandomly();
        _objects.Add(temp);
        ObjectMovementOnBelt();
        IsThrowableObject();
    }
    
    // MOVEMENT IS HERE
    void ObjectMovementOnBelt()
    {
        foreach (GameObject gameObjects in _objects)
        {
            gameObjects.transform.DOMove(new Vector3(0, 0.85f, 10), duration).SetEase(Ease.Linear);
        }
        Debug.Log("Goes");
    }
    
    // THROW CONDITIONS 
    private void IsThrowableObject()
    {
        if (_isObjectsListNull) return;
        foreach (GameObject gameObjects in _objects)
        {
            gameObjects.AddComponent<Rigidbody>();
        }
        GetComponent<ThrowControl>().ThrowObjects();
    }
    
    void CheckTheScore()
    {
        
    }
    
}
