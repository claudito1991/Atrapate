using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField] float lifeTime;
    private void OnEnable()
    {
        StartCoroutine(DelayedDestroy());
        
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(lifeTime);
    }
}
