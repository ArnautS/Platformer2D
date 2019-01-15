using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.tag == "EndLevel") {
			Debug.Log("Touched end");
			DataManagement.dataManagement.SaveData();			
			gameObject.GetComponent<PlayerHealth>().Die();
			DataManagement.dataManagement.deathCount = 0;
		}
	}
}
