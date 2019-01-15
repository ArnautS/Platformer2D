using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelPoint : MonoBehaviour {

	private GameObject entrance;
	[SerializeField]
	private GameObject exit;

	void Start() {
		entrance = gameObject;
	}

	void OnTriggerStay2D(Collider2D trig) {
		if (Input.GetButtonDown("Submit")) {
			trig.gameObject.transform.position = exit.transform.position;
		}
	}
}
