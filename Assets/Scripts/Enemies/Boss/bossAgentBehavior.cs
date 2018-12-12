using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossAgentBehavior : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;
	private Animator animator;
	public bool busy;
	public static bool isAttacking;
	public bool dead;
	// Use this for initialization
	void Start () {
		busy = false;
		dead = false;
		isAttacking = false;
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!busy){
            float distance = Vector3.Distance(target.position, transform.position);
			if(distance >= 6){
				agent.SetDestination(target.position);
			} else {
                agent.ResetPath();
				busy = true;
				attack();
			}
		} else {
            agent.ResetPath();
		}
    }

	void attack() {
		int x = Random.Range(0, 3);
		isAttacking = true;
		string attackType = "";
		switch(x){
			case 0: attackType = "attackRightArm"; break;
            case 1: attackType = "attackLeftArm"; break;
			case 2: attackType = "attackJump"; break;
        }
		animator.SetTrigger(attackType);
	}

	public void die() {
		dead = true;
		busy = true;
		isAttacking = false;
        animator.SetTrigger("die");
	}

	public void stun() {
		busy = true;
		isAttacking = false;
		animator.SetTrigger("stun");
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
