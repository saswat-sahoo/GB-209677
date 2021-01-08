using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    public GameObject gameover;
   
    private GameObject barrier;
    private GameObject prefab;
    private float health;

    // Start is called before the first frame update

    private void Start()
    {
        gameover.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        barrier = GameObject.FindGameObjectWithTag("barrier");
        health = barrier.GetComponent<barrierHealth>().health;
        if(health<=0)
        {
            StartCoroutine(Gameover());
        }
       

        

    }



    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(2f);
        gameover.SetActive(true);
        
    }
}
