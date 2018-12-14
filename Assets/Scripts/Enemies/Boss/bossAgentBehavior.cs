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
	public static bool isStunned;
	public bool dead;
	public static bool[] weakpointsLeft;
	
	// Use this for initialization
	void Start () {
		busy = false;
		dead = false;
		isAttacking = false;
		isStunned = false;
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		weakpointsLeft = new bool[3]{true, true, true};
	}
	
	// Update is called once per frame
	void Update () {
		if(!busy){
            float distance = Vector3.Distance(target.position, transform.position);
			if(distance >= 6){
				GetComponentInChildren<FootstepManager>().playFootsteps(true);
				animator.SetBool("walking", true);
				agent.SetDestination(target.position);
			} else {
				GetComponentInChildren<FootstepManager>().playFootsteps(false);
				animator.SetBool("walking", false);
				busy = true;
				Invoke("attack", 3);
			}
		} else {
            agent.ResetPath();
		}
    }

	//Weakpoint 1: Right Arm, Weakpoint 2: Right Arm, Weakpoint 3: Legs 
	int getAttackType(){
		int x = Random.Range(0, 3);
		if(!weakpointsLeft[0] && !weakpointsLeft[1] && !weakpointsLeft[2])
			return 4;
		if(weakpointsLeft[x])
			return x;
		else 
			return getAttackType();
	}

	void attack() {
		string attackType = "";
		switch(getAttackType()){
			case 0: attackType = "attackRightArm"; break;
            case 1: attackType = "attackLeftArm"; break;
			case 2: attackType = "attackJump"; break;
			case 4: return;
        }
		animator.SetTrigger(attackType);
	}

	public void die() {
		agent.ResetPath();
		GetComponent<BossAudio>().playDeath();
		dead = true;
		Player.getExp(50);
		isAttacking = false;
        animator.SetTrigger("die");
	}

	public void stun() {
		GetComponent<BossAudio>().playStun();
		busy = true;
		isStunned = true;
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
