using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{

    public float speed;
    float distanceTravelled = 0;
    Vector3 lastPosition;

    // Use this for initialization
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
		if(distanceTravelled > 30)
		{
			Destroy(this.gameObject);
		}
    }
}
