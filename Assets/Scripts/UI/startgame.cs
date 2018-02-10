using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startgame : MonoBehaviour {

	public Button startGame;

	void Start() {
		Button btn = startGame.GetComponent<Button>();
		btn.onClick.AddListener(StartTheGame);
	}

	void StartTheGame() {
		SceneManager.LoadScene("Level1");
	}
}
