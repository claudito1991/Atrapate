using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReveal : MonoBehaviour
{
    [SerializeField] GameObject Cartel;
    [SerializeField] float timeShowed;
    public int dialogoID;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Cartel.SetActive(true);
            Invoke("DestroyMe",timeShowed);
        }
    }

    private void OnEnable()
    {
        
    }

    public void DestroyMe()
    {
        SearchOtherID();
        Destroy(gameObject);
    }

    public void SearchOtherID()
    {
        var ids = FindObjectsOfType<TextReveal>();
            foreach(var id in ids)
        {
            if(id.dialogoID == dialogoID)
            {
                Destroy(id);
            }
        }
    }
}
