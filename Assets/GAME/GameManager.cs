using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

	public bool recording = true;

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (2);
		print (PlayerPrefsManager.IsLevelUnlocked (1));
		print (PlayerPrefsManager.IsLevelUnlocked (2));
	}
	
	// Update is called once per frame
	void Update () {
		recording = ! CrossPlatformInputManager.GetButton ("Fire1");
	}
}
