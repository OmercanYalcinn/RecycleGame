using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowControl : MonoBehaviour
{
    
    [SerializeField] private float throwForceOnYandZ = 1f;
    [SerializeField] private float throwForceOnX = 20f;
    
    private Vector2 startPositionWithFinger;
    private Vector2 endPositionReleaseFinger;
    private Vector3 direction;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void ThrowObjects()
    {
        // if you touched the screen
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPositionWithFinger = Input.GetTouch(0).position;
            }

            // if you release the touching
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endPositionReleaseFinger = Input.GetTouch(0).position;
            }

            direction = startPositionWithFinger - endPositionReleaseFinger;
        }
        
        rigidBody.isKinematic = false;
        rigidBody.AddForce(direction.x * throwForceOnX, -direction.y * throwForceOnYandZ, -direction.z * throwForceOnYandZ, ForceMode.Impulse);
    }
    
}
