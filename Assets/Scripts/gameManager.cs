using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	float timePassed;
	bool paused;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		timePassed = 0;
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		timePassed += 1 * Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.P)){
			pause();
		}
	}

	void pause(){
		paused = !paused;
		if(paused){
			pauseMenu.SetActive(true);
			Time.timeScale = 0;
			
		} else {
			pauseMenu.SetActive(false);
			Time.timeScale = 1;
		}
	}
}
