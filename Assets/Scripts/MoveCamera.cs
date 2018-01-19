﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public float newX;
	public float newY;

	public float newMaxX;
	public float newMaxY;
	public float newMinX;
	public float newMinY;


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("Move camera, X: " + newX + " Y: " + newY );
		Camera camera = Camera.main;

		camera.GetComponent<CameraCtrl>().maxX = newMaxX;
		camera.GetComponent<CameraCtrl>().maxY = newMaxY;
		camera.GetComponent<CameraCtrl>().minX = newMinX;
		camera.GetComponent<CameraCtrl>().minY = newMinY;
	}
}
