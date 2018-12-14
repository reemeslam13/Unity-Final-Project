using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour {

	public AudioClip bossStart;
	public AudioClip bossStun;
	public AudioClip bossDeath;
	public AudioClip bossAttack;
	

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().PlayOneShot(bossStart);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playStun(){
		GetComponent<AudioSource>().PlayOneShot(bossStun);
	}

	public void playDeath(){
		GetComponent<AudioSource>().PlayOneShot(bossDeath);
	}

	public void playAttack(){
		GetComponent<AudioSource>().PlayOneShot(bossAttack);
	}
}
