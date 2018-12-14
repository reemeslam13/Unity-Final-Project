using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErikaAudioController : MonoBehaviour {


	public AudioClip erikaDetect;
	public AudioClip erikaDeath;
	bool detected;

	// Use this for initialization
	void Start () {
		detected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playDetect(){
		if(!detected){
			GetComponent<AudioSource>().PlayOneShot(erikaDetect);
			detected = true;
		}
	}

	public void playDeath(){
		GetComponent<AudioSource>().PlayOneShot(erikaDeath);
	}

}
