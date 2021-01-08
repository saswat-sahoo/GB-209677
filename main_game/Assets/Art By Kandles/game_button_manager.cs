using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_button_manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pause;
    public AudioSource sound;
    //pause button
    private void Start()
    {
        pause.SetActive(false);
        sound.Play();
      
    }
    public void onpause()
    {
        Time.timeScale = 0;
        //music
        sound.Pause();
        pause.SetActive(true);
        
    }

    //replay button
    public void replay()
    {
        SceneManager.LoadScene(2);
        sound.Play();
    }

    //continue
    public void docontinue()
    {
        Time.timeScale = 1;
        //music
        sound.Play();
        pause.SetActive(false);
    }


    //main_menu
    public void mainmenu ()
    {
        SceneManager.LoadScene(0);
        
    }

    //quit
    public void doquit()
    {
        Application.Quit();
    }

}
