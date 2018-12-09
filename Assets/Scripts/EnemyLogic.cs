using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public int maxHealth = 50;
    public int health;
    public GameObject player;
    public int attackDamage = 10;
    

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        bool hit = GetComponent<VampireController>().hit;
        bool dead = GetComponent<VampireController>().dead;
        if(col.tag == "sword" && MariaController.mariaAttacking){
            int damage = player.GetComponent<Player>().attackDamage * player.GetComponentInChildren<MariaController>().attackType;
            health -= damage;
            print("Enemy HP: " + health + " / " + maxHealth);
            Player.rage = (Player.rage > 100) ? 100 : Player.rage + 10;
            print("RAGE: " + Player.rage);
            if(health <= 0){
                print("ouch im dead");
                GetComponent<VampireController>().dead = true;
                GetComponentInChildren<Animator>().SetTrigger("death");
            } else {
                GetComponentInChildren<Animator>().SetTrigger("attacked");
            }
        }
    }
}
