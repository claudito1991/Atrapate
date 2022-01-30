using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSC;
    [SerializeField] AudioClip[] musicToPlay;
    private bool isHappyScene = true;

    
    [SerializeField] [Range(0f, 2f)] float newSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isHappyScene = true;
        audioSC.clip = musicToPlay[0];
        audioSC.Play();
    }

    // Update is called once per frame
    void Update()
    {
        MusicObsolte();
    }

    private void MusicObsolte()
    {
        if (isHappyScene)
        {
            if (audioSC.isPlaying)
            {
                return;
            }
            else
            {
                audioSC.clip = musicToPlay[0];
                audioSC.Play();
            }
        }

        else

        {
            if (audioSC.isPlaying)
            {
                return;
            }
            else
            {

                audioSC.clip = musicToPlay[1];
                audioSC.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / newSpeed);
                audioSC.Play();


            }



        }
    }

    public void ChangeMusic(bool happyState)
    {
        if(happyState)
        {
           
            audioSC.clip = musicToPlay[0];
            audioSC.Play();
        }
        else
        {
            
            audioSC.clip = musicToPlay[1];
            audioSC.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / newSpeed);
            audioSC.Play();
        }
    }
}
