using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;

    public void play()
    {
        StartCoroutine(load());
    }


    IEnumerator load()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(2);


        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            float progress =Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }


    public void quit()
    {
        Application.Quit();
    }

    public void instructions()
    {
        SceneManager.LoadScene(1);
    }

    public void back()
    {
        SceneManager.LoadScene(0);
    }

    public void high()
    {
        SceneManager.LoadScene(3);
    }

}
