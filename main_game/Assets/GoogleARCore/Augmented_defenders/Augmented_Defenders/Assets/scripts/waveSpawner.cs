using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveSpawner : MonoBehaviour
{
	
	private GameObject[] enemy;
	public Transform spawnPoint;
	public wave_tracker wave;
    public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private Vector3 scale;
	public GameObject enemyprfab;
	private bool ispaused;
	public GameObject pausemenu;
    private int wavenumber = 0;
	private int prevwavenumber=0;


    private void Start()
    {
		wave = GameObject.FindGameObjectWithTag("wave").GetComponent<wave_tracker>();
	}

    void Update()
	{
		wavenumber = wave.wave_number;
		if(prevwavenumber!=wavenumber)
        {
			StartCoroutine(delay());
			
			prevwavenumber = wavenumber;
		}
		
		enemy = GameObject.FindGameObjectsWithTag("zombie");
		if(enemy.Length>=wavenumber && enemy.Length!=0)
        {
			return;
        }

		scale = GameObject.FindGameObjectWithTag("prefab").transform.localScale;

		/*if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);*/

		//waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}
	IEnumerator delay()
    {
		yield return new WaitForSeconds(3f);
		StartCoroutine(SpawnWave());
	}
	IEnumerator SpawnWave()
	{
		

		for (int i = 0; i < wavenumber; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(.5f);
		}


	}

	void SpawnEnemy()
	{
		Vector3 position = new Vector3(spawnPoint.position.x , spawnPoint.position.y, spawnPoint.position.z );
		

		GameObject zombie= (GameObject) Instantiate(enemyprfab, position, spawnPoint.rotation,spawnPoint);
		
		//float sc =  1.25f;
		//zombie.transform.localScale =new Vector3(sc, sc, sc);
		
		zombie.transform.localPosition = new Vector3(zombie.transform.localPosition.x+ Random.Range(-2f, 5f) , zombie.transform.localPosition.y, zombie.transform.localPosition.z);
	}









}
