using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float sensitivityX = 20f;
    public float sensitivityY = 1;
    public Camera cam;
    public int jumps;
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
        if (!MariaController.mariaAttacking && !MariaController.beingHit && !dead)
        {
            int running = (Input.GetKey(KeyCode.LeftShift)) ? 2 : 1;
            //Forward motion
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * running * Time.deltaTime);
            transform.Translate(Input.GetAxis("Horizontal") * movementSpeed * running * Time.deltaTime, 0, 0);
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

        if (Input.GetKeyDown(KeyCode.Space) && !dead)
        {
            if (jumps > 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("jump");
                jumps--;
                GetComponentInChildren<Rigidbody>().AddForce(new Vector3(0, 6f, 0), ForceMode.Impulse);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "lava")
        {
            GetComponentInChildren<Player>().healthPoints = 0;
            dead = true;
            GetComponentInChildren<Animator>().SetTrigger("die");
        }

        if (col.tag == "enemyHand" && !Input.GetKey(KeyCode.LeftControl))
        {
            bool gettingAttacked = col.gameObject.GetComponentInParent<VampireController>().isAttacking && !Input.GetKey(KeyCode.LeftControl);
            if (gettingAttacked)
            {
                gameObject.GetComponentInChildren<Player>().healthPoints -= 10;
                MariaController.beingHit = true;
                
                if (gameObject.GetComponentInChildren<Player>().healthPoints <= 0)
                    die();
                else
                    hit();
            }
        }
        else if (col.tag == "weakpoint1" || col.tag == "weakpoint2" && !Input.GetKey(KeyCode.LeftControl))
        {
            bool gettingAttacked = bossAgentBehavior.isAttacking && !Input.GetKey(KeyCode.LeftControl);
            if (gettingAttacked)
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -5f), ForceMode.Impulse);
                GetComponentInChildren<Player>().healthPoints -= 30;
                MariaController.beingHit = true;

                if (GetComponentInChildren<Player>().healthPoints <= 0)
                    die();
                else
                    hit();
            }
        }

        if ((col.tag == "arrow" || col.tag == "Wall") && !Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.GetComponentInChildren<Player>().healthPoints -= 10;
            MariaController.beingHit = true;

            if (gameObject.GetComponentInChildren<Player>().healthPoints <= 0)
                die();
            else
                hit();
        } else if(col.tag == "Rock"){
            gameObject.GetComponentInChildren<Player>().healthPoints -= 10;
            Destroy(col.gameObject);
            MariaController.beingHit = true;

            if (gameObject.GetComponentInChildren<Player>().healthPoints <= 0)
                die();
            else
                hit();

        }

        if (col.tag == "gate" && Player.wavesCompleted == 3){
            SceneManager.LoadScene(2);
            PlayerPrefs.SetInt("xp", Player.experience);
            PlayerPrefs.SetInt("level", Player.level);
            PlayerPrefs.SetInt("sp", Player.skillPoints);
            PlayerPrefs.SetInt("rage", Player.rage);
        }
    }

    void die(){
                GetComponentInChildren<Animator>().SetTrigger("die");
                GetComponentInChildren<MariaAudioController>().playDeath();
                dead = true;
                GetComponent<Collider>().enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
    }

    void hit(){
                GetComponentInChildren<Animator>().SetTrigger("hit");
                GetComponentInChildren<MariaAudioController>().playHit();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "obstacle")
        {
            gameObject.GetComponentInChildren<Player>().healthPoints -= 3;
            MariaController.beingHit = true;
            Debug.Log("Maria HP: " + gameObject.GetComponentInChildren<Player>().healthPoints);
            if (gameObject.GetComponentInChildren<Player>().healthPoints <= 0)
            {
                GetComponentInChildren<Animator>().SetTrigger("die");
                dead = true;
                //GetComponent<Collider>().enabled = false;
            }
            else
            {
                GetComponentInChildren<Animator>().SetTrigger("hit");
            }
        }

        if (col.gameObject.tag == "chest")
        {
            col.gameObject.GetComponent<Animator>().SetBool("Collect",true);
            GetComponentInChildren<Player>().refillHealth();
            GetComponentInChildren<MariaAudioController>().playCollectItem();
        }
        if (col.gameObject.tag == "ground")
            jumps = 2;
    }
}
