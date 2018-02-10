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

	int hp = 20;

	bool grounded;
	public Transform groundCheck;
	float groundRadius = 2.0f;
	public LayerMask whatIsGround;

	public float jumpForce = 700f;
	public float jumpGravity;
	Transform firePos;

	public bool alive = true;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

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

		rigidbody2d.velocity = new Vector2(move * maxSpeed, Mathf.Clamp(rigidbody2d.velocity.y, -150f, 500f));
		if (move > 0 && !facingRight) {
			Flip();
		} else if (move < 0 && facingRight) {
			Flip();
		}
	}

	void Update() {
		// Jumping
		if (grounded && (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Z))) {
			rigidbody2d.AddForce(new Vector2(0, jumpForce * jumpGravity));
			SoundManager.PlaySound("jump");
			anim.SetBool("Ground", false);
			grounded = false;
		}

		//Shooting
		if ((Input.GetKeyDown(KeyCode.JoystickButton1) || 
			Input.GetKeyDown(KeyCode.X)) && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				Fire();
		}

		// Bør nok ligge i egen klasse for keyboard-controls..
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("ENEMY") || other.gameObject.CompareTag("ENEMYBULLET")) {
			SoundManager.PlaySound("playerHit");

			hp--;
			Debug.Log("HP left: " + hp);
			if (hp == 0) {
				alive = false;
				anim.SetBool("Alive", false);
				// change scene to game over / continue screen
				StartCoroutine(ChangeToScene("GameOver"));
			}
		}
	}


	public IEnumerator ChangeToScene(string scene) {
		yield return new WaitForSecondsRealtime(0.4f);
		SceneManager.LoadScene(scene);
	}

	void Fire() {
		SoundManager.PlaySound("fire");

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