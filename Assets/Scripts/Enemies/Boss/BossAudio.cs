using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour {

	public AudioClip bossStart;
	public AudioClip bossStun;
	public AudioClip bossDeath;
	

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().PlayOneShot(bossStart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void playStun(){
		
	}
}
