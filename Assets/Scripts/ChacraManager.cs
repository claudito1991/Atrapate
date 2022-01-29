using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacraManager : MonoBehaviour
{
    [SerializeField] BulletMotion[] bulletTypes;
    [SerializeField] GameObject player;
    [SerializeField] int score;
    [SerializeField] Transform gameStartPosition;
    [SerializeField] float minWinDistance;
    public bool isHappyScene;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void IncreaseScore(int amount)
    {
        score += Mathf.Abs(amount);
    }

    public void DecreaseScore(int amount)
    {
        score -= Mathf.Abs(amount);
        Debug.Log($"actual score{score}");
        if(score<0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        //player death vfx
        Destroy(player);
    }

    public BulletMotion BulletSelector()
    {
        if (score < 10)
        {
            //sfx chacra switch
            //UI update chacra icon
            return bulletTypes[0];
        }
        if (score >= 10 && score < 20)
        {
            
            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[1];
        }
        if (score >= 20 && score < 30)
        {

            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[2];
        }
        if (score >= 30 && score < 40)
        {

            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[3];
        }

        if (score >= 40 && score < 50)
        {

            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[4];
        }


        if (score >= 50 && score < 60)
        {

            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[5];
        }

        else
        {
            player.GetComponent<PlayerController>().PlayerDamage(5);
            return bulletTypes[1];
        }
      
        
        
    }

    public void Victory()
    {
       
        float distanceToStart = Vector3.Distance(player.transform.position, gameStartPosition.position);
        Debug.Log($"Winning request{distanceToStart}");
        if (distanceToStart > minWinDistance)
        {
            //Winning UI

            Destroy(player);
        }

    }

    public void HappyState(bool happy)
    {
        isHappyScene = happy;
    }


}
