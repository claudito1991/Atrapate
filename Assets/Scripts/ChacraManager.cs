using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class ChacraManager : MonoBehaviour
{
    [SerializeField] BulletMotion[] bulletTypes;
    [SerializeField] GameObject player;
    [SerializeField] int score;
    [SerializeField] Transform gameStartPosition;
    [SerializeField] float minWinDistance;
    [SerializeField] int maxScore;
    [SerializeField] IconoID[] UIiconos;
    public BulletMotion choosenBullet;
    public bool isHappyScene;
    private InLevelMenu levelManager;
    [SerializeField] TMP_Text text;
    [SerializeField] SpriteRenderer sadSky;
    [SerializeField] float skyVariationSpeed;
    [SerializeField] PostProcessVolume nightmare;
    [SerializeField] PostProcessVolume dream;
    [SerializeField] float tiempoBlend;
    


    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<InLevelMenu>();
        InitialBullet();
        dream.weight = 1;
        nightmare.weight = 0;
    }
    private void Update()
    {
        if(!isHappyScene)
        {
            sadSky.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, skyVariationSpeed));
        }
        
    }

    private void InitialBullet()
    {
        TurnIcons(0);
        player.GetComponent<PlayerController>().PlayerDamage(5);
        choosenBullet= bulletTypes[0];
    }

    public void IncreaseScore(int amount)
    {
        score += Mathf.Abs(amount);
        choosenBullet = BulletSelector();
        if(score>maxScore)
        {
            score = maxScore;
        }
        
    }

    public void DecreaseScore(int amount)
    {
        score -= Mathf.Abs(amount);
        choosenBullet = BulletSelector();
        Debug.Log($"choosen bullet{choosenBullet}");
        if(score<0)
        {
            
            GameOver();
        }
    }

    private void GameOver()
    {
        //player death vfx
        levelManager.Death_VFX(transform);
        text.text = "La pesadilla continua";
        Destroy(player);
        
        
        
    }

    public BulletMotion BulletSelector()
    {
        if (score < 10)
        {
            //sfx chacra switch
            //UI update chacra icon
            TurnIcons(0);
            player.GetComponent<PlayerController>().PlayerDamage(10);
            return bulletTypes[0];
        }
        if (score >= 10 && score < 20)
        {
            
            player.GetComponent<PlayerController>().PlayerDamage(15);
            TurnIcons(1);
            return bulletTypes[1];
        }
        if (score >= 20 && score < 30)
        {
            TurnIcons(2);
            player.GetComponent<PlayerController>().PlayerDamage(20);
            return bulletTypes[2];
        }
        if (score >= 30 && score < 40)
        {
            TurnIcons(3);
            player.GetComponent<PlayerController>().PlayerDamage(25);
            return bulletTypes[3];
        }

        if (score >= 40 && score < 50)
        {
            TurnIcons(4);
            player.GetComponent<PlayerController>().PlayerDamage(35);
            return bulletTypes[4];
        }


        else
        {
            TurnIcons(5);
            player.GetComponent<PlayerController>().PlayerDamage(40);
            return bulletTypes[5];
        }
      
        
        
    }

    public void TurnIcons(int iconoNum)
    {
        for(int i = 0 ; i <=iconoNum; i++)
        {
            UIiconos[i].gameObject.SetActive(true);
        }

        for(int i = UIiconos.Length - 1; i > iconoNum; i--)
        {
            UIiconos[i].gameObject.SetActive(false);
        }
    }

    public void Victory()
    {
       
        float distanceToStart = Vector3.Distance(player.transform.position, gameStartPosition.position);
        Debug.Log($"Winning request{distanceToStart}");
        if (distanceToStart > minWinDistance)
        {
            //Winning UI
            //Winning music

            text.text = "La pesadilla se acab?";
            Destroy(player);
        }

    }

    public void HappyState(bool happy)
    {
        isHappyScene = happy;
    }

    public void ChangePostPro(string estado)
    {
        Debug.Log("coroutine launched");
        StartCoroutine(changeAcrossTime(estado));
    }

    IEnumerator changeAcrossTime(string estado)
    {
        
        float elapsedTime = 0;
        float waitTime = 3f;


        if(estado == "dream")
        {
            while (elapsedTime < waitTime)
            {
                
                dream.weight = Mathf.Lerp(0f, 1f, (elapsedTime / waitTime));
                nightmare.weight = Mathf.Lerp(1f, 0f, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        if(estado == "nightmare")
        {
            while (elapsedTime < waitTime)
            {

                dream.weight = Mathf.Lerp(1f, 0f, (elapsedTime / waitTime));
                nightmare.weight = Mathf.Lerp(0f, 1f, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

       
    }

}
