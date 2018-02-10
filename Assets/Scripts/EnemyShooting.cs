using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject leftBullet, rightBullet;
	public Transform firePos;
	public float fireRate;
	private float nextFire;

	bool facingRight = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.transform.rotation.eulerAngles.y == 180) {
			facingRight = true;
		}

		// Delay shooting
		if (Time.time > nextFire) {
			nextFire = Time.time + (fireRate * Random.Range(0.3f, 1.5f));
			Fire();
		}
	}

	void Fire() {

		if (facingRight) {
			Instantiate(rightBullet, firePos.position, Quaternion.identity);
		}

		if (!facingRight) {
			Instantiate(leftBullet, firePos.position + new Vector3(10, 0, 0), Quaternion.identity);
		}
	}
}
