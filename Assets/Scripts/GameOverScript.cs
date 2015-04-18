using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	void OnGUI() {
		const int buttonHeight = 60;
		const int buttonWidth = 120;

		Rect buttonRect = new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		);

		if (GUI.Button (buttonRect, "Retry!")) {
			Application.LoadLevel("Stage1");
		}

		Rect menuRect = new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
		);

		if (GUI.Button (menuRect, "Back to Menu")) {
			Application.LoadLevel("Menu");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
