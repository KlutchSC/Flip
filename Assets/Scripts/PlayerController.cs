using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed = 10.0f;
	
	Rigidbody2D myBody;
	Vector3 movement;

	public AudioClip swapSound;
	public AudioClip landingSound;
	public AudioClip noKeySound;
	public AudioClip damageSound;
	public AudioClip hurtSound;
	public AudioClip pickupSound;

	public string moveDirection;

	// Use this for initialization
	void Start () {
		myBody  = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput ();
		MovePlayer (moveDirection);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Hazzard") {
			AudioSource.PlayClipAtPoint(hurtSound, Camera.main.transform.position);
			GameControl.control.livesRemaining--;
			if (GameControl.control.livesRemaining == 0) {
				Application.LoadLevel("GameOver");
			} else {
				Application.LoadLevel(GameControl.control.curLevel);
			}
		}
		if (other.gameObject.tag == "KillZone") {
			AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
			this.gameObject.SetActive (false);
			GameControl.control.livesRemaining--;
			if (GameControl.control.livesRemaining == 0) {
				Application.LoadLevel("GameOver");
			} else {
				Application.LoadLevel(GameControl.control.curLevel);
			}
		}
		if (other.gameObject.tag == "WinZone") {
			if (GameControl.control.hasKey == true){
				Application.LoadLevel (GameControl.control.nextLevel);
			} else {
				AudioSource.PlayClipAtPoint(noKeySound, Camera.main.transform.position);
			}
		}
		if (other.gameObject.tag == "Key") {
			AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
			other.gameObject.SetActive (false);
			GameControl.control.hasKey = true;
		}
	}

	public void CheckInput () {
		if (Input.GetKey (KeyCode.D)) {
			MovePlayer("right");
		}
		
		if (Input.GetKey (KeyCode.A)) {
			MovePlayer("left");
		}

		if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.A)) {
			MovePlayer("stop");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			GravitySwap();
		}
	}

	public void ChangeDirection (string direction) {
		moveDirection = direction;
	}
	
	public void GravitySwap () {
		AudioSource.PlayClipAtPoint(swapSound, Camera.main.transform.position);
		Physics2D.gravity = new Vector3 (0.0f, (Physics2D.gravity.y * -1.0f), 0.0f);
	}

	public void MovePlayer (string direction) {
		if (direction == "right") {
			movement = myBody.velocity;
			movement.x = 1.0f * moveSpeed * Time.deltaTime;
			myBody.velocity = movement;
		} else if (direction == "left") {
			movement = myBody.velocity;
			movement.x = -1.0f * moveSpeed * Time.deltaTime;
			myBody.velocity = movement;
		} else if (direction == "stop") {
			movement = myBody.velocity;
			movement.x = 0.0f * moveSpeed * Time.deltaTime;
			myBody.velocity = movement;
		}
	}
}
