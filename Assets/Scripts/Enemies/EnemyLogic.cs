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

    public static int hitCounter;

    // Use this for initialization
    void Start()
    {
        hitCounter = 0;
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
        if (gameObject.tag == "bora3y")
        {
            hit = GetComponent<VampireController>().hit;
            dead = GetComponent<VampireController>().dead;
            if (dead)
            {
                return;
            }
        }
        else if (gameObject.tag == "erika")
        {
            dead = GetComponent<ErikaController>().dead;
            if (dead)
            {
                return;
            }
        }

        // print(MariaController.hits.Values);

        if (col.tag == "sword" && MariaController.mariaAttacking && hitCounter == 1)
        {
                // MariaController.hits[col.gameObject] = 0;
                Debug.Log("getting hit");
                int damage = player.GetComponent<Player>().attackDamage * player.GetComponentInChildren<MariaController>().attackType;
                print("da damage" + damage);
                if (MariaController.rageActivated)
                    damage *= 2;

                print("da damage" + damage);
                health -= damage;
                print("HP: " + health);
                Player.rage = (Player.rage > 100) ? 100 : Player.rage + 10;
                hitCounter = 0;
            if (health <= 0)
            {
                Player.getExp(50);
                if (gameObject.tag == "bora3y")
                {
                    GetComponent<VampireController>().dead = true;
                    GetComponent<Bora3yAudioController>().playDeath();
                    GetComponentInChildren<Animator>().SetTrigger("death");
                }
                else if (gameObject.tag == "erika")
                {
                    GetComponent<ErikaController>().dead = true;
                    GetComponent<ErikaAudioController>().playDeath();
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
