using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;
	Rigidbody2D rigidbody2d;
	public GameObject leftBullet, rightBullet;

	Animator anim;

	bool grounded;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public float jumpGravity;
	Transform firePos;

	public bool alive = true;

	// Use this for initialization
	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		firePos = transform.Find("firePos");

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(move));

		rigidbody2d.velocity = new Vector2(move * maxSpeed, rigidbody2d.velocity.y);

		if (move > 0 && !facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Update() {
		if (grounded && Input.GetKeyDown(KeyCode.Space)) {
			rigidbody2d.AddForce(new Vector2(0, jumpForce * jumpGravity));
			
			anim.SetBool("Ground", false);
		}

		if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl)) {
			Fire();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("ENEMY")) {
			alive = false;
			anim.SetBool("Alive", false);
			// change scene to game over / continue screen
			StartCoroutine(ChangeToScene("GameOver"));

		}
	}


	public IEnumerator ChangeToScene(string scene) {
		yield return new WaitForSecondsRealtime(0.4f);
		SceneManager.LoadScene(scene);
	}

	void Fire() {
		if (facingRight) {
			Instantiate(rightBullet, firePos.position, Quaternion.identity);
		}
		if (!facingRight) {
			Instantiate(leftBullet, firePos.position, Quaternion.identity);
		}
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}