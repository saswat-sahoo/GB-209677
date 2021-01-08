using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class wave_tracker : MonoBehaviour
{
    public int wave_number;

    public int kills;
    public int killcounter;
    public  TextMeshProUGUI score;
   
    // Start is called before the first frame update
    void Start()
    {
        wave_number = 1;
        kills = 0;
        killcounter = 0;
        score.text = "KILLS:"+killcounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(kills==wave_number && kills!=0)
        {
            wave_number++;
            kills = 0;
        }
        score.text = "KILLS:" + killcounter.ToString();

        if(killcounter>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", killcounter);
        }
       

    }
}
