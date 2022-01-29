using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacraManager : MonoBehaviour
{
    [SerializeField] BulletMotion[] bulletTypes;
    [SerializeField] GameObject player;
    [SerializeField] int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += Mathf.Abs(score);
    }

    public void DecreaseScore(int amount)
    {
        score -= Mathf.Abs(score);
        if(score<0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Destroy(player);
    }

    public BulletMotion BulletSelector()
    {
        if (score < 10)
        {
            return bulletTypes[2];
        }
        if (score >= 10 && score < 50)
        {
            //trigger GameOver
            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[0];
        }

        else
        {
            player.GetComponent<PlayerController>().PlayerDamage(5);
            return bulletTypes[1];
        }
      
        
        
    }


}
