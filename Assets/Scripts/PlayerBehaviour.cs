using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public static float movementSpeed = 0.05f;
    public float sensitivityX = 20f;
    public float sensitivityY = 1;
    public Camera cam;
    public int jumps;
    public GameObject maria;
    public bool dead;

    // Use this for initialization
    void Start()
    {
        jumps = 2;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!MariaController.mariaAttacking && !MariaController.beingHit && !dead){
            int running = (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;
			//Forward motion
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * running);
            //Horizontal rotation
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * sensitivityX, 0.0f);
        }
        //Vertical camera rotation
        cam.transform.Rotate(Input.GetAxis("Mouse Y") * sensitivityY * -1, 0.0f, 0.0f);
        if (cam.transform.eulerAngles.x >= 35.0f && cam.transform.eulerAngles.x <= 300.0f)
        {
            cam.transform.eulerAngles = new Vector3(
            35.0f,
            cam.transform.eulerAngles.y,
            cam.transform.eulerAngles.z
        );
        }
        else if (cam.transform.eulerAngles.x >= 300.0f)
            {
                cam.transform.eulerAngles = new Vector3(
                0.0f,
                cam.transform.eulerAngles.y,
                cam.transform.eulerAngles.z
            );
        }

        if(Input.GetKeyDown(KeyCode.Space) && !dead){
            if(jumps > 0){
                GetComponentInChildren<Animator>().SetTrigger("jump");
                jumps--;
                GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
            }
        }

      
    }

    void OnTriggerEnter(Collider col){
        //print();
        if(col.tag == "enemyHand"){
            bool gettingAttacked = col.gameObject.GetComponentInParent<VampireController>().isAttacking && !Input.GetKey(KeyCode.LeftControl);
            if(gettingAttacked){
                gameObject.GetComponentInChildren<Player>().healthPoints -= col.gameObject.GetComponentInParent<EnemyLogic>().attackDamage;
				MariaController.beingHit = true;
                Debug.Log("Maria HP: " + gameObject.GetComponentInChildren<Player>().healthPoints);
                if (gameObject.GetComponentInChildren<Player>().healthPoints <= 0)
                {
                    GetComponentInChildren<Animator>().SetTrigger("die");
                    dead = true;
                    GetComponent<Collider>().enabled = false;
                }
                else
                {
                    GetComponentInChildren<Animator>().SetTrigger("hit");
                }
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag == "ground")
            jumps = 2;
        if (col.gameObject.CompareTag("Rock"))
            Destroy(col.gameObject);




    }


}
