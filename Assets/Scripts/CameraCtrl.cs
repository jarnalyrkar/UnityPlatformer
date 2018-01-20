using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraCtrl : MonoBehaviour {

	public Transform player;
	public float scale = 4f;
	public float minX, maxX;
	public float minY, maxY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(
			Mathf.Clamp(50 + player.position.x, minX, maxX), 
			Mathf.Clamp(player.position.y, minY, maxY),
							transform.position.z);
	}
}
