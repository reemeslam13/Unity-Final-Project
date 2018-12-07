using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	float timePassed;

	// Use this for initialization
	void Start () {
		timePassed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += 1 * Time.deltaTime;
	}
}
