using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MariaAudioController : MonoBehaviour {

	public AudioClip collectItem;
	public AudioClip mariaDeath;
	public AudioClip mariaRage;
	public AudioClip mariaHit;
	public AudioSource AS;

	// Use this for initialization
	void Start () {
		AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void playHit(){
		AS.PlayOneShot(mariaHit);
	}
	public void playRage(){
		AS.PlayOneShot(mariaRage);
	}
	public void playCollectItem(){
		AS.PlayOneShot(collectItem);
	}
	public void playDeath(){
		AS.PlayOneShot(mariaDeath);
	}
}
