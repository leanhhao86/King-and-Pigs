using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;
    [SerializeField] private float minX, maxX;
    private Vector3 tempPos;

    void LateUpdate()
    {
        tempPos = transform.position;
        transform.position =  new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z) + offset;

        // if (tempPos.x < minX) 
        // {
        //     tempPos.x = minX;
        // }
        // else if (tempPos.x > maxX)
        // {
        //     tempPos.x = maxX;
        // } else 
        // {
        //     transform.position = tempPos;
        // }

    }
}
