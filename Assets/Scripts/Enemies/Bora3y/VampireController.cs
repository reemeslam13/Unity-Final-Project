using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VampireController : MonoBehaviour {
	public float lookRadius = 10f;
    public GameObject player;
    NavMeshAgent agent;
    public bool isAttacking;
    Vector3 startLocation;
    public GameObject enemy;
    Animator anim;
    public bool dead;
    public bool hit = false;

    public bool canAttack;

    private Transform target;

	// Use this for initialization
	void Start () {
        canAttack = true;
        isAttacking = false;
        dead = false;
        agent = GetComponent<NavMeshAgent>();
        target = player.transform;
        startLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        anim = enemy.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if(!dead && !isAttacking){
            float distance = Vector3.Distance(target.position, transform.position);

            if(distance <= lookRadius){
                GetComponentInChildren<FootstepManager>().playFootsteps(true);
                agent.SetDestination(target.position);
                anim.SetBool("isRunning", true);
                GetComponent<Bora3yAudioController>().playDetect();
                anim.SetBool("isIdle", false);

                if (distance <= agent.stoppingDistance){
                    GetComponentInChildren<FootstepManager>().playFootsteps(false);
                    //Attack target
                    if(canAttack)
                        attack();
                    //Face the target
                    FaceTarget();
                }
            }
            else{
                agent.SetDestination(startLocation);
            }

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
    }

    void attack(){
        canAttack = false;
        GetComponentInChildren<Animator>().SetTrigger("attack");
    }

    public void InvokeCanAttack(float time){
        Invoke("canAttackTrue", time);
    }

    void canAttackTrue(){
        canAttack = true;
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

    public void InvokeAttack(){
        Invoke("InvokeAttacking", 0.5f);
    }

    void InvokeAttacking(){
        isAttacking = true;
    }
}
