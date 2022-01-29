using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapChanger : MonoBehaviour
{
    [SerializeField] GameObject tilemapFeliz;
    [SerializeField] GameObject tilemapTriste;
    [SerializeField] GameObject[] colinasFelices;
    [SerializeField] GameObject[] colinasTriste;
    [SerializeField] BoxCollider2D triggerSwitch;
    [SerializeField] ChacraManager gameManager;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position,new Vector3(2,2,2));
    }
    private void Start()
    {
        
        tilemapTriste.SetActive(false);
        tilemapFeliz.SetActive(true);
        foreach (GameObject colina in colinasFelices)
        {
            colina.SetActive(true);
        }
        foreach (GameObject colina in colinasTriste)
        {
            colina.SetActive(false);
        }
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //MUSICA AMBIENTE TRISTE
            //CAMBIO DE PANTALLA VFX
            Debug.Log("Triggered");
            if(gameManager.isHappyScene)
            {
                Debug.Log("Entra en happy scene true");
                
                tilemapFeliz.GetComponent<TilemapRenderer>().sortingOrder = 4;
                tilemapFeliz.SetActive(false);
                tilemapTriste.GetComponent<TilemapRenderer>().sortingOrder = 5;
                tilemapTriste.SetActive(true);
                gameManager.HappyState(false);

                foreach(GameObject colina in colinasFelices)
                {
                    colina.SetActive(false);
                }
                foreach (GameObject colina in colinasTriste)
                {
                    colina.SetActive(true);
                }
            }

            else
            {
                // MUSICA AMBIENTE FELIZ
                //CAMBIO DE PANTALLA VFX
                Debug.Log("Entra en happy scene false");
                tilemapTriste.GetComponent<TilemapRenderer>().sortingOrder = 4;
                tilemapTriste.SetActive(false);
                tilemapFeliz.GetComponent<TilemapRenderer>().sortingOrder = 5;
                tilemapFeliz.SetActive(true);
                gameManager.HappyState(true);

                foreach (GameObject colina in colinasFelices)
                {
                    colina.SetActive(true);
                }
                foreach (GameObject colina in colinasTriste)
                {
                    colina.SetActive(false);
                }

                gameManager.Victory();

            }

          
        }


    }
}
