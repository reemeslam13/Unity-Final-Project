using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KratosController : MonoBehaviour
{
    public static float movementSpeed = 0.05f;
    public float sensitivityX = 20f;
    public float sensitivityY = 1;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!MariaController.isAttacking){
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
    }
}
