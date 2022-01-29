using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChacraManager : MonoBehaviour
{
    [SerializeField] GameObject[] bulletTypes;
    [SerializeField] GameObject player;
    private int score;

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

    public GameObject BulletSelector()
    {
        if (score >= 10 && score < 20)
        {
            //trigger GameOver
            return bulletTypes[0];
        }

        if(score >= 20 && score < 30) 
        {
            return bulletTypes[1];
        }

        return bulletTypes[2];
    }


}
