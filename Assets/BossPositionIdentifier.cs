using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPositionIdentifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Vector3 getTransform(){
		return GetComponent<Transform>().position;
	}
}
