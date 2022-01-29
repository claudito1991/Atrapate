using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private void OnEnable()
    {
        Invoke("DelayedDestroy", lifeTime);



    }

    void DelayedDestroy()
    {
        Destroy(gameObject);
    }
}
