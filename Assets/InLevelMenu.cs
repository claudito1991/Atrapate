using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class InLevelMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] ParticleSystem death_vfx;
    public GameObject text;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(levelMenu.activeSelf)
            {
                levelMenu.SetActive(false);
            }
            else
            {
                levelMenu.SetActive(true);
            }
        }
    }
    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOver(string textoFinDeJuego)
        
    {
        text.SetActive(true);
        text.GetComponent<TextMeshPro>().text = textoFinDeJuego;


    }

    public void Death_VFX( Transform ubicacion)
    {
        Instantiate(death_vfx, ubicacion.transform.position, Quaternion.identity);
    }
}
