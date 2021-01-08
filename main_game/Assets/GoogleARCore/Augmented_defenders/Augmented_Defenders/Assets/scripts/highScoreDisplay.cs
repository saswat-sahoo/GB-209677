using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class highScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "HIGH SCORE : " + PlayerPrefs.GetInt("HighScore", 0);
    }

  public void back()
    {
        SceneManager.LoadScene(0);
    }
}
