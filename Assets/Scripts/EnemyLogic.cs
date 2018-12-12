﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    public int maxHealth = 50;
    public int health;
    public GameObject player;
    public int attackDamage = 10;
    public ProgressBar hp;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
        hp.BarValue = (int)(((double)health / (double)maxHealth) * 100.0);
    }

    void OnTriggerEnter(Collider col)
    {

        bool hit, dead;
        if (gameObject.tag == "vampire")
        {
            hit = GetComponent<VampireController>().hit;
            dead = GetComponent<VampireController>().dead;
        }
        else if (gameObject.tag == "erika")
        {
            dead = GetComponent<ErikaController>().dead;
        }

        if (col.tag == "sword" && MariaController.mariaAttacking)
        {
            Debug.Log("getting hit");
            int damage = player.GetComponent<Player>().attackDamage * player.GetComponentInChildren<MariaController>().attackType;
            health -= damage;
            print("HP: " + health);
            Player.rage = (Player.rage > 100) ? 100 : Player.rage + 10;
            if (health <= 0)
            {

                if (gameObject.tag == "vampire")
                {
                    GetComponent<VampireController>().dead = true;
                    GetComponentInChildren<Animator>().SetTrigger("death");
                }
                else if (gameObject.tag == "erika")
                {
                    GetComponent<ErikaController>().dead = true;
                    GetComponentInChildren<Animator>().SetBool("death", true);
                }
            }
            else
            {
                GetComponentInChildren<Animator>().SetTrigger("attacked");
            }
        }
    }
}
