using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kratos : MonoBehaviour
{
    int t;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Animator>().GetBool("HitByRock")&&(int)Time.time==t){
            gameObject.GetComponent<Animator>().SetBool("HitByRock", false);

        }
    }

    public void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.CompareTag("Rock"))
        {
           
            Destroy(collision.gameObject);
            gameObject.GetComponent<Animator>().SetBool("HitByRock", true);
            t = (int)(Time.time + 1);


        }
    }
   
}
