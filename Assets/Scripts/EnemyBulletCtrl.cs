using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCtrl : MonoBehaviour {

	public Vector2 speed;
	Rigidbody2D rb;
	public GameObject playerObject;
	private Player player;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = speed;
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed;
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Player")) {
			Destroy(gameObject);
			player.hp--;
			player.SetHPText();
			
			SoundManager.PlaySound("playerHit");
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("SOLID")) {
			Destroy(gameObject);	
		}
	}

}
