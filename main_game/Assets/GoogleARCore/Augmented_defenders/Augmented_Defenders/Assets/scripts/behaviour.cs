﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    public Animator anim;
    public float speed = 15f;
    private Rigidbody rb;
    private Collider col;
    private GameObject enemy;
    public GameObject attacking;
    private bool isalive;
    private string currentAnimaton;
    const string death = "Z_death_A";
    const string attack = "Z_attack_A";
    const string run = "Z_run_rm";
    public bool isattacking;
    private float tempspeed;
    public ParticleSystem particle;
    private Vector3 scale;
    public wave_tracker wave;
    private bool done;
    public AudioSource deathaudio;
   
    // Update is called once per frame

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tempspeed = speed;
        isalive = true;
        particle.Stop();
        attacking.SetActive(false);
        wave = GameObject.FindGameObjectWithTag("wave").GetComponent<wave_tracker>();
        
    }

    void Update()
    {
        scale = GameObject.FindGameObjectWithTag("prefab").transform.localScale;
        if (isalive)
        {
            transform.position += (transform.forward * (speed*(scale.magnitude)/4) * Time.deltaTime);
            transform.localScale= new Vector3(1.25f, 1.25f, 1.25f);
        }
       
        enemy = GameObject.FindGameObjectWithTag("zombie");
        if (Input.GetKey("w"))
        {
            ChangeAnimationState(death);
            rb.velocity = Vector3.zero;
            isalive = false;
            particle.Play();
            deathaudio.Play();
            attacking.SetActive(false);
            if (!done)
            {
                wave.kills++;
                wave.killcounter++;
                done = true;
            }
           
            StartCoroutine(destroy());
            

        }
        if(GameObject.FindGameObjectWithTag("Finish")==null)
        {
            ChangeAnimationState(run);
            speed = tempspeed;
            Debug.Log("ruuuun");
        }

        if(currentAnimaton==attack)
        {
            rb.velocity = Vector3.zero;
            isattacking = true;
            attacking.SetActive(true);

        }
        else
        {
            isattacking = false;
            attacking.SetActive(false);
        }

    }


    IEnumerator destroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (collision.gameObject.tag == "barrier")
        {
            ChangeAnimationState(attack);
            speed = 0f;
            rb.velocity = Vector3.zero;
        }
    }
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        anim.Play(newAnimation);
        currentAnimaton = newAnimation;
    }
   public void Die()
    {
        ChangeAnimationState(death);
        rb.velocity = Vector3.zero;
        isalive = false;
        particle.Play();
        deathaudio.Play();
        attacking.SetActive(false);
        if (!done)
        {
            wave.kills++;
            wave.killcounter++;
            done = true;
        }
        StartCoroutine(destroy());
        
    }

}
