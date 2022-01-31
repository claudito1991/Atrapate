using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class InLevelMenu : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    [SerializeField] ParticleSystem death_vfx;

    public bool isMenuVisible;

    private void Start()
    {
        isMenuVisible = false;
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isMenuVisible)
            {
                levelMenu.SetActive(true);
            }
            else
            {
                levelMenu.SetActive(false);
            }
            isMenuVisible = !isMenuVisible;
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



    public void Death_VFX( Transform ubicacion)
    {
        Instantiate(death_vfx, ubicacion.transform.position, Quaternion.identity);
    }
}
