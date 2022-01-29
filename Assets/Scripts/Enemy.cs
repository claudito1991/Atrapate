using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject playerGo;
    [SerializeField] float enemySpeed;
    [SerializeField] float attackRange;
    [SerializeField] int enemyDamage;
    [SerializeField] int playerReward;
    
    private SpriteRenderer enemySprite;
    private Rigidbody2D enemyRB;
    private Vector3 playerPosition;
    private ChacraManager gameManager;

    
    

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        enemyRB = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<ChacraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpriteFlip();
    }

    private void PlayerSpriteFlip()
    {
        playerPosition = playerGo.transform.position- transform.position;


        //Pasado un umbral se decide si el sprite del player debe girar hacia un lado u el otro. 
        if (playerPosition.x < -0.01f)
        {
            enemySprite.flipX = true;
        }

        if (playerPosition.x > 0.01f)
        {
            enemySprite.flipX = false;
        }
        Debug.Log(playerPosition);
    }

    private void FixedUpdate()
    {
        EnemyChasing();
        
    }

    private void EnemyChasing()
    {

        enemyRB.velocity = new Vector2(playerPosition.x * enemySpeed, enemyRB.velocity.y);
        var playerDistance = Vector3.Distance(playerPosition, transform.position);

        if(playerDistance < attackRange)
        {
            EnemyAttack();
        }
    }

    private void EnemyAttack()
    {
        gameManager.DecreaseScore(enemyDamage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            gameManager.IncreaseScore(playerReward);
        }
    }
}
