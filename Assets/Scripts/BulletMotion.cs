using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    [SerializeField] float shootSpeed;
    [SerializeField] float rotationAngle;
    public float smoothTime = 2f;
    private float convertedTime = 200f;
    
    
    private bool flipedX;


    private void Update()
    {
        DirectionOfShooting(flipedX);
    }

    public void DirectionOfShooting(bool fliped)
    {
        //Según el valor del flip la bala va a girar y a dirigirse a un lado o al otro. 
        flipedX = fliped;
        if(fliped)
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * shootSpeed, transform.position.y, transform.position.z);
          
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            //La rotacion no está funcionando

            var smooth = Time.deltaTime * smoothTime * convertedTime;
            transform.Rotate(Vector3.forward * smooth);
        }

        else
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * shootSpeed, transform.position.y, transform.position.z);
        }
        
    }
}
