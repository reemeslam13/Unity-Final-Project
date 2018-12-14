using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepManager : MonoBehaviour {
	AudioSource AS;
	bool playing;
	// Use this for initialization
	void Start () {
		playing = false;
		AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playFootsteps(bool play){
		if(play && !playing){
			playing = true;
			AS.Play();
		} else {
			if(!play && playing){
				playing = false;
				AS.Pause();
			}
		}
	}
}
