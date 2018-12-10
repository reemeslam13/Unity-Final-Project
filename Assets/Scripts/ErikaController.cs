using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikaController : MonoBehaviour
{

    public bool isFiring;
    public bool firingDone;
    public bool dead;
    public Animator animator;
    public GameObject firePoint;
    public GameObject arrowObj;
    public GameObject target;
    public Transform targetTransform;

    // Use this for initialization
    void Start()
    {
        targetTransform = target.transform;
        firingDone = true;
        //animator.SetInteger("state", 0);
        isFiring = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            float distance = Vector3.Distance(targetTransform.position, transform.position);

            if (firingDone == false)
            {
                spawnArrow();
                firingDone = true;
            }

            if (distance <= 10)
            {

                FaceTarget();
                if (!isFiring)
                {
                    isFiring = true;
                    animator.SetBool("shoot", true);
                }
            }

            else if (distance > 10)
            {
                animator.SetBool("shoot", false);
                //animator.SetInteger("state", 0);
            }
        }
    }

    public void cooldownShoot()
    {
        Invoke("stopShooting", 3);
    }


    public void stopShooting()
    {
        isFiring = false;
    }

    public void spawnArrow()
    {
        GameObject arrow;
        if (firePoint != null)
        {
            arrow = Instantiate(arrowObj, firePoint.transform.position, Quaternion.identity);
            arrow.transform.LookAt(new Vector3(targetTransform.position.x, targetTransform.position.y + 1.5f, targetTransform.position.z));
        }
    }

    public void FaceTarget()
    {
        Vector3 direction = (targetTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
