using UnityEngine;

public class Movement : MonoBehaviour {

	public float maxSpeed = 10f;

	Rigidbody2D rigidbody2d;

	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		rigidbody2d.velocity = new Vector2(move * maxSpeed, -2);
	}
}
