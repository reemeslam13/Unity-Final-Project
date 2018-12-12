using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossAgentBehavior : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;
	private Animator animator;
	public bool busy;
	// Use this for initialization
	void Start () {
		busy = false;
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
		if(!busy){
			if(distance >= 11){
				agent.SetDestination(target.position);
			} else {
				busy = true;
				attack();
			}
		}
    }

	void attack(){
		int x = Random.Range(0, 3);
		string attackType = "";
		switch(x){
			case 0: attackType = "attackRightArm"; break;
            case 1: attackType = "attackLeftArm"; break;
			case 2: attackType = "attackJump"; break;
        }
		animator.SetTrigger(attackType);
	}

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
