using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public void loadScene() {
		SceneManager.LoadScene("Level1");
	}

	public void exitGame() {
		Application.Quit();
		Debug.Log("Application quit.");
	}
		
}
