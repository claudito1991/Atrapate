using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject playerGO;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 offset = new Vector3(0, 0, 10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(playerGO == null)
        {
            return;
        }
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerGO.transform.position  + offset, movementSpeed * Time.deltaTime);
        transform.position = smoothPosition;
        
    }
}
