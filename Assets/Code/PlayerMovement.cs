using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody2D rb;
	private SpriteRenderer sr;
	[SerializeField]
	private int playerJumpPower;
	[SerializeField]
	private int playerSpeed;
	[SerializeField]
	private int enemyBouncePower;
	private float halfSpriteSizeY;
	private float colliderOffset = 0.05f;
	private float velocityOffset = 0.01f;

	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D>();
		sr = gameObject.GetComponent<SpriteRenderer>();
		halfSpriteSizeY = sr.size.y/2;
	}

	// Update is called once per frame
	void Update() {
		PlayerMove();
		PlayerRaycast();
    }

	void PlayerMove() {
		float moveX = Input.GetAxis("Horizontal");
		//CONTROLS
		if (Input.GetButtonDown("Jump") && rb.velocity.y > -velocityOffset && rb.velocity.y < velocityOffset) {
			Jump(playerJumpPower);
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			Debug.Log("Loading data");
			DataManagement.dataManagement.LoadData();
		}
		//ANIMATIONS
		if (moveX != 0) {
			GetComponent<Animator>().SetBool("IsRunning", true);
		} else {
			GetComponent<Animator>().SetBool("IsRunning", false);
		}
		//PLAYER DIRECTION		
		if (moveX < 0) {
			sr.flipX = true;
		}
		else if (moveX > 0) {
			sr.flipX = false;
		}
		//PHYSICS
		rb.velocity = new Vector2(moveX * playerSpeed, rb.velocity.y);
	}

	void Jump(int power) {
		//JUMPING
		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * power);
	}

	void PlayerRaycast() {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);

		if (hit && hit.distance <= halfSpriteSizeY + colliderOffset && hit.collider.tag == "Enemy") {
			Jump(enemyBouncePower);
			hit.collider.GetComponent<EnemyHealth>().Die();
		}
	}
}
