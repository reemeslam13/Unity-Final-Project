using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointLogic : MonoBehaviour {
	public GameObject[] parents;
	int countOfHits;

	// Use this for initialization
	void Start () {
		countOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "sword" && MariaController.mariaAttacking){
			countOfHits++;
			if(countOfHits == 3){
				for(int i=0; i< parents.Length; i++){
                    parents[i].transform.localScale = new Vector3(0, 0, 0);
					BossLogic.weakPointGone = true;
				}
			}
		}
	}
}
