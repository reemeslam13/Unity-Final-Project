using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaController : MonoBehaviour
{
    public int state;
    public static bool mariaAttacking;
    public static bool beingHit;
    public Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        state = 0;
        animator.SetInteger("state", 0);
        mariaAttacking = false;
        beingHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            state = 3;
            animator.SetTrigger("heavyAttack");
			mariaAttacking = true;
        } else if (Input.GetMouseButtonDown(0)){
            state = 4;
            animator.SetTrigger("lightAttack");
            mariaAttacking = true;
        }
		if (Input.GetAxis("Vertical") != 0)
        {
            //Running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                state = 2;
                animator.SetInteger("state", 2);
            }
            else
            {
                //Walking
                state = 1;
                animator.SetInteger("state", 1);
            }
        }
        else
        {
            //Idle
            state = 0;
            animator.SetInteger("state", 0);
        }
    }
}
