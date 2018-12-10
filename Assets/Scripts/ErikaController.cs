using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikaController : MonoBehaviour
{

    public static bool isFiring;
    public static bool firingDone;
    public Animator animator;
    public GameObject firePoint;
    public GameObject arrowObj;
    public GameObject target;
    public Transform targetTransform;
    public static int state;

    // Use this for initialization
    void Start()
    {
        targetTransform = target.transform;
        firingDone = true;
        state = 0;
        animator.SetInteger("state", 0);
        isFiring = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(targetTransform.position, transform.position);
        if (state == 1)
        {
            if (firingDone == false)
            {
                spawnArrow();
                firingDone = true;
            }
        }
        if (distance <= 10)
        {
            animator.SetTrigger("shoot");
            state = 1;
            animator.SetInteger("state", 1);
        }
        else if (distance > 10)
        {
            state = 0;
            animator.SetInteger("state", 0);
            animator.ResetTrigger("shoot");
        }
        if (distance <= 10)
        {
            FaceTarget();
        }
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
