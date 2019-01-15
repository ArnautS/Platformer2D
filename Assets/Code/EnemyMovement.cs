using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	[SerializeField]
	private int EnemySpeed = 1;
	[SerializeField]
	private int XMoveDirection = 1;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
		rb.velocity = new Vector2(XMoveDirection * EnemySpeed, rb.velocity.y);
		// Hit distance should depend on enemy size
		if (hit && hit.distance < 0.7f) {
			XMoveDirection = -XMoveDirection;
			// TODO bug: player only dies when hit with opposite movement direction
			if (hit.collider.tag == "Player") {
				hit.collider.gameObject.GetComponent<PlayerHealth>().Die();
			}
        }
    }
	

}
