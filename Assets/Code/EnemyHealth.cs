using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    void Update() {
		if (gameObject.transform.position.y < -6) {
			Die();
		}
	}

	public void Die() {
		Destroy(gameObject);
	}
}
