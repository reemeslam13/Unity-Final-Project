using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
	public float lookRadius = 10f;
    public GameObject player;
    NavMeshAgent agent;
    Vector3 startLocation;
    public GameObject enemy;
    Animator anim;

    private Transform target;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
        startLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        anim = enemy.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float distance = Vector3.Distance(target.position, transform.position);

        if(distance <= lookRadius){
            agent.SetDestination(target.position);
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);

            if (distance<= agent.stoppingDistance){
                //Attack target

                //Face the target
                FaceTarget();
            }
        }
        else{
            agent.SetDestination(startLocation);
        }

      // if(Vector3.Distance(transform.position,startLocation)< startLocation.magnitude ){

        //}

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isRunning", false);
                }
            }
        }
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
         }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
