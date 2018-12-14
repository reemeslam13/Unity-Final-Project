using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPointLogic : MonoBehaviour {
	public GameObject[] parents;
	int countOfHits;
	int weaknessType;

	// Use this for initialization
	void Start () {
		countOfHits = 0;

		switch(tag){
			case "weakpoint1" : weaknessType = 0; break;
			case "weakpoint2" : weaknessType = 1; break;
			case "weakpoint3" : weaknessType = 2; break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "sword" && MariaController.mariaAttacking && !bossAgentBehavior.isStunned){
			countOfHits++;
			if(countOfHits == 5){
				for(int i=0; i< parents.Length; i++){
					bossAgentBehavior.weakpointsLeft[weaknessType] = false;
                    parents[i].transform.localScale = new Vector3(0, 0, 0);
					BossLogic.weakPointGone = true;
				}
			}
		}
	}
}
