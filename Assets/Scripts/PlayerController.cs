using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float movementSpeed;
    [SerializeField] Vector3 yOffset;
    [SerializeField] float rayLongitude;
    [SerializeField] BulletMotion bulletPrefab;
    [SerializeField] float xFirepointOffset;
    [SerializeField] float yFirepointOffset;

    [SerializeField] BulletMotion[] bulletTypes;
    public bool isPoweredUp;

    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRB;
    private bool playerRenderDirection;


    private float HorizontalMovement;
    public bool Grounded;

    private void Start()
    {
        playerRB = GetComponentInChildren<Rigidbody2D>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Update()
    {

        HorizontalMovement = Input.GetAxisRaw("Horizontal");
        PlayerSpriteFlip();

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireSequence();
        }


        Debug.Log($"Horizontal Movement: {HorizontalMovement}");
        GroundedCheck();

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            //Si el player está en el suelo nos permite saltar
            Jump();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(xFirepointOffset,yFirepointOffset,0), 0.5f);
    }

    private void FireSequence()
    {
        //Se chequea si el personaje consumió o no un powerUP y según esto se instancia un tipo de bullet u otro. 
        BulletMotion bulletInstantiated = null;

        if (isPoweredUp)
        {
            bulletInstantiated = Instantiate(bulletTypes[0], transform.position, Quaternion.identity);
        }
        
        else
        {
            bulletInstantiated = Instantiate(bulletTypes[1], transform.position, Quaternion.identity);
        }
        

        //Se chequea el estado del sprite del player. Según hacia qué lado esté mirando se va a invocar una función que cambie
        //el lugar en el que se instancia la bullet y que cambie la dirección de movimiento de la misma. 
        if(playerSprite.flipX)
        {
            bulletInstantiated.DirectionOfShooting(true);
            bulletInstantiated.transform.position = transform.position + new Vector3(-xFirepointOffset, yFirepointOffset, 0);
        }
        else
        {
            bulletInstantiated.DirectionOfShooting(false);
            bulletInstantiated.transform.position = transform.position + new Vector3(xFirepointOffset, yFirepointOffset, 0);
        }
    }

    private void PlayerSpriteFlip()
    {
        //Pasado un umbral se decide si el sprite del player debe girar hacia un lado u el otro. 
        if (HorizontalMovement < -0.01f)
        {
            playerSprite.flipX = true;
        }

        if (HorizontalMovement > 0.01f)
        {
            playerSprite.flipX = false;
        }
    }

    private void GroundedCheck()
    {
        //Chequea si el player está o no en el suelo
        Debug.DrawRay(transform.position + yOffset, Vector3.down * rayLongitude, Color.red);
        if (Physics2D.Raycast(transform.position + yOffset, Vector3.down, rayLongitude))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }

    private void Jump()
    {
        playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse) ;
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(HorizontalMovement * movementSpeed, playerRB.velocity.y);
    }
}
