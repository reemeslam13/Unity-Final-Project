using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour {

	public int health;
	public int maxHealth = 200;
	public static bool weakPointGone;
    public ProgressBar hp;


    // Use this for initialization
    void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        hp.BarValue = (int)(((double)health / (double)maxHealth) * 100.0);
		weakPointDestroyed();
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "sword" && MariaController.mariaAttacking){
			health -= (int)(0.05*maxHealth);
            print("BOSS LEVEL: " + health + " / " + maxHealth);
			if(health <= 0){
				GetComponent<bossAgentBehavior>().die();
			}
		}
    }

    void weakPointDestroyed()
    {
		if(weakPointGone){
            weakPointGone = false;
            health -= (int)(0.2 * maxHealth);
            print("::::::WEAK POINT GONE: " + health + " / " + maxHealth);
            if (health <= 0)
            {
                GetComponent<bossAgentBehavior>().die();
            } else {
                GetComponent<bossAgentBehavior>().stun();
			}
		}
    }
}
