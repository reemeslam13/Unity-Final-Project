using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public int maxHealth = 50;
    public int health;
    public GameObject player;
    public int attackDamage = 10;

    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col){
        
        bool hit, dead;
        if (gameObject.tag == "vampire") {
            hit = GetComponent<VampireController>().hit;
            dead = GetComponent<VampireController>().dead;
        } else if(gameObject.tag == "erika") {
            dead = GetComponent<ErikaController>().dead;
        }
   
        if(col.tag == "sword" && MariaController.mariaAttacking){
            int damage = player.GetComponent<Player>().attackDamage * player.GetComponentInChildren<MariaController>().attackType;
            health -= damage;
            print("HP: " + health);
            Player.rage = (Player.rage > 100) ? 100 : Player.rage + 10;
            if(health <= 0){
                
                if (gameObject.tag == "vampire")
                    GetComponent<VampireController>().dead = true;
                else if (gameObject.tag == "erika")
                    GetComponent<ErikaController>().dead = true;

                GetComponentInChildren<Animator>().SetTrigger("death");
            } else {
                GetComponentInChildren<Animator>().SetTrigger("attacked");
            }
        }
    }
}
