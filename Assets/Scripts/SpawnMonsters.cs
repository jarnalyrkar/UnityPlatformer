using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMonsters : MonoBehaviour {

	public Transform enemyFrog;
	public Transform enemySkelly;
	public Transform enemyGhost;
	public Transform enemyBat;

	// Use this for initialization
	void Start () {
		// first horizontal section
		Instantiate(enemyFrog, new Vector2(100, 1), Quaternion.identity);
		Instantiate(enemyFrog, new Vector2(200, 1), Quaternion.identity);
		Instantiate(enemyFrog, new Vector2(280, 1), Quaternion.identity);
		Instantiate(enemyFrog, new Vector2(320, 1), Quaternion.identity);
		Instantiate(enemyFrog, new Vector2(400, 35), Quaternion.identity);
		Instantiate(enemyFrog, new Vector2(500, 65), Quaternion.identity);
		Instantiate(enemySkelly, new Vector2(300, -30), Quaternion.identity);
		Instantiate(enemySkelly, new Vector2(600, -30), Quaternion.identity);
		
	}

}
