using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    
    private bool flipedX;


    private void Update()
    {
        DirectionOfShooting(flipedX);
    }

    public void DirectionOfShooting(bool fliped)
    {
        flipedX = fliped;
        if(fliped)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * shootSpeed, transform.position.y, transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * shootSpeed, transform.position.y, transform.position.z);
        }
        
    }
}
