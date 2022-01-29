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
    [SerializeField] int enemyHealth;
    [SerializeField] float enemyAttackCooldown;
    public float currentCooldown;


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
        currentCooldown = 0;
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
        //Debug.Log(playerPosition);
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
            currentCooldown = Time.time;
            Debug.Log($"current cooldown: {currentCooldown}");
            if(currentCooldown>enemyAttackCooldown)
            {
                EnemyAttack();
                currentCooldown = 0f;
            }
            
        }
    }

    private void EnemyAttack()
    {
        gameManager.DecreaseScore(enemyDamage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
           // Debug.Log("Collisioned");
            enemyHealth -= playerGo.GetComponent<PlayerController>().playerDamage;
            //Debug.Log(enemyHealth);

            if(enemyHealth<0)
            {
                EnemyDeath();
            }
            
        }
    }

    private void EnemyDeath()
    {
        gameManager.IncreaseScore(playerReward);
        Destroy(gameObject);
    }


}
