using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KratosController : MonoBehaviour
{
    public float movementSpeed;
    public float sensitivity = 0.2f;
    public Camera cam;

    // Use this for initialization
    void Start()
    {
        movementSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
		//Forward motion
        transform.Translate(0, 0, -Input.GetAxis("Vertical") * movementSpeed);
		//Horizontal rotation
        transform.Rotate(0.0f, Input.GetAxis("Mouse X") * 20.0f, 0.0f);
		//Vertical camera rotation
        cam.transform.Rotate(-Input.GetAxis("Mouse Y"), 0.0f, 0.0f);
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
