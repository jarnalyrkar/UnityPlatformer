using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnMonsters : MonoBehaviour {

	private Vector2 cameraPos;
	private Dictionary<string, Vector2> triggers = new Dictionary<string, Vector2>();
	public Transform enemyFrog;
	public Transform enemySkelly;
	public Transform enemyGhost;
	public Transform enemyBat;
	private int triggerCounter;

	void Start() {
		triggerCounter = 0;

		// Add triggers:
		triggers.Add("Trigger 0", new Vector2(-35, 17));
		triggers.Add("Trigger 1", new Vector2(965, -135));
		triggers.Add("Trigger 2", new Vector2(965, -290));
		triggers.Add("Trigger 3", new Vector2(965, -450));
		triggers.Add("Trigger 4", new Vector2(965, -590));
		triggers.Add("Trigger 5", new Vector2(965, -730));
		triggers.Add("Trigger 6", new Vector2(965, -860));
		triggers.Add("Trigger 7", new Vector2(965, -1000));
		triggers.Add("Trigger 8", new Vector2(1680, -1000));
	}

	// Use this for initialization
	void FixedUpdate () {
		
		cameraPos = new Vector2(Camera.main.transform.position.x,
			Camera.main.transform.position.y);
		
		// Set quaternion for flipping sprites
		Quaternion rightDirection = Quaternion.identity;
		rightDirection.eulerAngles = new Vector3(0, 180, 0);

		// first horizontal section
		if (cameraPos == triggers["Trigger 0"] && triggerCounter == 0) {
			Instantiate(enemyFrog, new Vector2(100, 1), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(200, 1), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(280, 1), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(320, 1), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(400, 35), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(500, 65), Quaternion.identity);
			Instantiate(enemySkelly, new Vector2(300, -30), Quaternion.identity);
			Instantiate(enemySkelly, new Vector2(600, -30), Quaternion.identity);
			Instantiate(enemyGhost, new Vector2(683, 1), Quaternion.identity);
			Instantiate(enemyFrog, new Vector2(683, 70), Quaternion.identity);
			Instantiate(enemyGhost, new Vector2(990, 32), Quaternion.identity);
			Instantiate(enemyGhost, new Vector2(930, 0), rightDirection);

			triggerCounter++;
		}

		// first vertical section
		if (cameraPos == triggers["Trigger 1"] && triggerCounter == 1) {
			Debug.Log("TRIGGERED 1");

			Instantiate(enemyFrog, new Vector2(100, 1), Quaternion.identity);
			triggerCounter++;
		}

		// second vertical section
		if (cameraPos == triggers["Trigger 2"] && triggerCounter == 2) {
			Debug.Log("TRIGGERED 2");
			triggerCounter++;
		}

		// third vertical section
		if (cameraPos == triggers["Trigger 3"] && triggerCounter == 3) {
			Debug.Log("TRIGGERED 3");
			triggerCounter++;
		}

		// fourth vertical section
		if (cameraPos == triggers["Trigger 4"] && triggerCounter == 4) {
			Debug.Log("TRIGGERED 4");
			triggerCounter++;
		}
		// fifth vertical section
		if (cameraPos == triggers["Trigger 5"] && triggerCounter == 5) {
			Debug.Log("TRIGGERED 5");
			triggerCounter++;
		}
		// seventh vertical section
		if (cameraPos == triggers["Trigger 6"] && triggerCounter == 6) {
			Debug.Log("TRIGGERED 6");
			triggerCounter++;
		}
		// last horizontal section
		if (cameraPos == triggers["Trigger 7"] && triggerCounter == 7) {
			Debug.Log("TRIGGERED 7");
			triggerCounter++;
		}
		// Boss section
		if (cameraPos == triggers["Trigger 8"] && triggerCounter == 8) {
			Debug.Log("TRIGGERED 8");
			triggerCounter++;
		}


	
	}
		
}