using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToCamera : MonoBehaviour
{
    [SerializeField] GameObject bullet_gfx;
    private Transform cam;
    
    // Start is called before the first frame update
    void Start()
    {
        //Este código detecta donde está la cámara y gira al GFX del bullet para que siempre la mire. Debería ahorrar las rotaciones en la mayoría de las bullets

        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        var camAux = new Vector3(cam.position.x, cam.position.y, -cam.position.z);
        bullet_gfx.transform.LookAt(camAux);
    }


}
