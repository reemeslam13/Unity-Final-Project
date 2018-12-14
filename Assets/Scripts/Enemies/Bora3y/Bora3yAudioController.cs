using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bora3yAudioController : MonoBehaviour {

	public AudioClip bora3yDetect;
	public AudioClip bora3yDeath;
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
			GetComponent<AudioSource>().PlayOneShot(bora3yDetect);
			detected = true;
		}
	}

	public void playDeath(){
		GetComponent<AudioSource>().PlayOneShot(bora3yDeath);
	}

}
