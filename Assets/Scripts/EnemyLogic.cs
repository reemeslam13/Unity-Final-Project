using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public int maxHealth = 50;
    public int health;
    public GameObject player;
    

	// Use this for initialization
	void Start () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        if(col.tag == "sword" && MariaController.isAttacking && !VampireController.hit){
			VampireController.hit = true;
            int damage = player.GetComponent<kratos>().attackDamage;
            health -= damage;
            print("Enemy HP: " + health + " / " + maxHealth);
            if(health <= 0){
                print("ouch im dead");
                VampireController.dead = true;
                GetComponentInChildren<Animator>().SetTrigger("death");
            } else {
                GetComponentInChildren<Animator>().SetTrigger("attacked");
            }
        }
    }
}
