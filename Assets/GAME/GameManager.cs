using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;

	private bool isPaused = false;
	private float fixedDeltaTime;

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (2);
		print (PlayerPrefsManager.IsLevelUnlocked (1));
		print (PlayerPrefsManager.IsLevelUnlocked (2));
		fixedDeltaTime = Time.fixedDeltaTime;
		print (fixedDeltaTime);
	}
	
	// Update is called once per frame
	void Update () {
		recording = ! CrossPlatformInputManager.GetButton ("Fire1");

		// P key pauses and resumes game
		if (Input.GetKeyDown (KeyCode.P) && isPaused) {
			isPaused = false;
			ResumeGame ();
		} else if (Input.GetKeyDown (KeyCode.P) && !isPaused) {
			isPaused = true;
			PauseGame ();
		}
	}

	void PauseGame() {
		Time.timeScale = 0;
		Time.fixedDeltaTime = 0;
	}

	void ResumeGame() {
		Time.timeScale = 1;
		Time.fixedDeltaTime = fixedDeltaTime;
	}

	void OnApplicationFocus (bool hasFocus) {
		isPaused = !hasFocus;
	}

	void OnApplicationPause (bool pauseStatus) {
		isPaused = pauseStatus;
	}
}
