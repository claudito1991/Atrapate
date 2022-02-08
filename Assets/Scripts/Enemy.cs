using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject playerGo;
    public float enemySpeed;
    public float attackRange;
    public int enemyDamage;
    [SerializeField] int playerReward;
    public int enemyHealth;
    [SerializeField] float enemyAttackCooldown;
    public float nextAttack;
    [SerializeField] AudioSource enemyAudioSource;
    [SerializeField] AudioClip impactoRecibido;
    [SerializeField] ParticleSystem impact_vfx;


    private SpriteRenderer enemySprite;
    private Rigidbody2D enemyRB;
    private Vector3 playerPosition;
    private ChacraManager gameManager;
    private float playerDistance;
    private InLevelMenu levelManager;





    private void OnEnable()
    {
       

    }
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<InLevelMenu>();
        playerGo = GameObject.FindGameObjectWithTag("Player");
        enemySprite = GetComponentInChildren<SpriteRenderer>();
        enemyRB = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<ChacraManager>();
        nextAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerSpriteFlip();
        
    }

    private void PlayerSpriteFlip()
    {
        if(playerGo == null)
        {
            return;
        }

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
        EnemyAttack();
    }

    

    private void EnemyChasing()
    {

        //enemyRB.velocity = new Vector2(playerPosition.x * enemySpeed, enemyRB.velocity.y);
        transform.Translate(playerPosition.normalized * Time.deltaTime * enemySpeed);

    }

    private void EnemyAttack()
    {
        if(playerGo == null)
        {
            return;
        }
        playerDistance = Vector3.Distance(playerGo.transform.position, transform.position);
        float xDistance = Mathf.Abs(playerGo.transform.position.x - transform.position.x);
        Debug.Log($"player distance: {playerDistance}");
        Debug.Log($"player X distance: {xDistance}");

        if (xDistance < attackRange)
        {
            Debug.Log("Enemy attacks");
            if (Time.time > nextAttack)
            {
                //Enemy attack vfx/sfx
                gameManager.DecreaseScore(enemyDamage);
                
                nextAttack = Time.time + enemyAttackCooldown;
                

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            impact_vfx.Play();
            enemyAudioSource.PlayOneShot(impactoRecibido);
            Destroy(collision.gameObject);
            enemyHealth -= playerGo.GetComponent<PlayerController>().playerDamage;
            


            if(enemyHealth<0)
            {
                EnemyDeath();
            }
            
        }
    }

    private void EnemyDeath()
    {
        gameManager.IncreaseScore(playerReward);
        levelManager.Death_VFX(transform);
        //Enemy attack vfx death.
        Destroy(gameObject);
    }


}
