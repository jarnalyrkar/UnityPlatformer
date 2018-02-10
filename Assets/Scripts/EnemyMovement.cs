using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D body2D;
	bool facingRight;
	// Use this for initialization
	void Start () {
		body2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		body2D.velocity = new Vector2(-transform.localScale.x, 0) * speed;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("ENEMY")) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			
		}
		
	}
}
