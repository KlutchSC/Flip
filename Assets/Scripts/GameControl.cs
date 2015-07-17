using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public bool hasKey;

	public string curLevel;
	public string prevLevel;
	public string nextLevel;

	public int livesRemaining;

	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		livesRemaining = 3;
		curLevel = Application.loadedLevelName;
	}

	public void LoadNewLevel (string levelName) {
		Application.LoadLevel (levelName);
	}

	public void LoadSameLevel () {
		Application.LoadLevel (prevLevel);
	}

	void OnLevelWasLoaded(int level) {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy (gameObject);
		}
		prevLevel = curLevel;
		curLevel = Application.loadedLevelName;
		nextLevel = "Level02";
		hasKey = false;
		if (curLevel == prevLevel) {
			livesRemaining = livesRemaining;
		} else {
			livesRemaining = 3;
		}
	}
}
