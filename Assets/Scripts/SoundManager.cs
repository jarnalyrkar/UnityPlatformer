using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static AudioClip playerHitSound, fireSound, jumpSound, enemyDeathSound;
	static AudioSource audioSrc;

	// Use this for initialization
	void Start () {

		playerHitSound = Resources.Load<AudioClip>("playerHit");
		fireSound = Resources.Load<AudioClip>("fire");
		jumpSound = Resources.Load<AudioClip>("jump");
		enemyDeathSound = Resources.Load<AudioClip>("enemyDeath");

		audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip) { 
		switch (clip) {
		case "fire":
			audioSrc.PlayOneShot(fireSound);
			break;
		case "playerHit":
			audioSrc.PlayOneShot(playerHitSound);
			break;
		case "jump":
			audioSrc.PlayOneShot(jumpSound);
			break;
		case "enemyDeath":
			audioSrc.PlayOneShot(enemyDeathSound);
			break;
		}
	
	}
}
