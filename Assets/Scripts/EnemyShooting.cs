using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

	public GameObject bullet;
	public Transform firePos;
	public float fireRate;
	private float nextFire;

	bool facingRight = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Fire();
		}
	}

	void Fire() {
		if (!facingRight) {
			Instantiate(bullet, firePos.position, Quaternion.identity);
		}

	}
}
