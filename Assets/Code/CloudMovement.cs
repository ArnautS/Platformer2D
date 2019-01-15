using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	private float xPos;

    void Start() {
		xPos = transform.position.x;
    }

    void Update() {
		xPos -= Time.deltaTime * speed;
		// Depends on size of the level
		if (xPos < -40) {
			xPos = 40;
		}
		transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
		
    }
}
