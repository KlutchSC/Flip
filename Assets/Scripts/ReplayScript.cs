using UnityEngine;
using System.Collections;

public class ReplayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadSameLevel () {
		Application.LoadLevel (GameControl.control.curLevel);
	}

	public void LoadMainMenu () {
		Application.LoadLevel ("MainMenu");
	}
}
