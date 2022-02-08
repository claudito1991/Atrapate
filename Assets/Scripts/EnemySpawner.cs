using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform levelStartPosition;
   
    [SerializeField] GameObject enemySpawnPosition;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float enemyStatsModifier;
    [SerializeField] int enemyQuantity;
    //[SerializeField] float enemySpeedModifier;
    [SerializeField] int MaxLevelSize = 1000;
    [SerializeField] float healthModifier;
    [SerializeField] float speedModifier;
    [SerializeField] float damageModifier;
    [SerializeField] float attackRangeModifier;

    private float distanceToStart;
    //private Collider2D collider;
    private Bounds bounds;


    private void Start()
    {
       // collider = enemySpawnPosition.GetComponent<Collider2D>();
        bounds = enemySpawnPosition.GetComponent<Collider2D>().bounds;
        var distanceVector = enemySpawnPosition.transform.position - levelStartPosition.position;
        distanceToStart = Mathf.RoundToInt(Vector3.SqrMagnitude(distanceVector));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(enemySpawnPosition.transform.position, new Vector3(2, 2, 2));
    }


    internal void SpawnEnemies()
    {



  


        Debug.Log("Spawn enemies");
        for(int i = 0; i<enemyQuantity; i++)
        {

            float offsetX = UnityEngine.Random.Range(-bounds.extents.x, bounds.extents.x);
            float offsetY = UnityEngine.Random.Range(-bounds.extents.y, bounds.extents.y);
            float offsetZ = UnityEngine.Random.Range(-bounds.extents.z, bounds.extents.z);

            var enemigo = Instantiate(enemyPrefab, enemySpawnPosition.transform.position, enemyPrefab.transform.rotation);
            float modifier = ((distanceToStart * enemyStatsModifier) / MaxLevelSize) +1;
            Debug.Log(modifier);
            enemigo.GetComponent<Enemy>().enemyHealth = Mathf.RoundToInt( modifier*healthModifier * enemigo.GetComponent<Enemy>().enemyHealth);
            enemigo.GetComponent<Enemy>().enemySpeed = Mathf.RoundToInt(modifier *speedModifier* enemigo.GetComponent<Enemy>().enemySpeed);
            enemigo.GetComponent<Enemy>().enemyDamage = Mathf.RoundToInt(modifier *damageModifier* enemigo.GetComponent<Enemy>().enemyDamage);
            enemigo.GetComponent<Enemy>().attackRange = Mathf.RoundToInt(modifier * attackRangeModifier*enemigo.GetComponent<Enemy>().attackRange);

            enemigo.GetComponent<Transform>().localScale = modifier * enemigo.GetComponent<Transform>().localScale;
            enemigo.transform.position = bounds.center + new Vector3(offsetX, offsetY, 0);

        }

        Destroy(gameObject);


    }




    // Start is called before the first frame update

}
