using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D myBody;
    const float moveSpeed = 6.0f;

	void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
	}
	
	void Update()
    {
        CheckInput();
	}

    void MovePlayer(float direction)
    {
        myBody.velocity = new Vector2(((moveSpeed * 1.2f) * direction), myBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "LevelExit")
        {
            if (GameController.controller.hasKey == true)
            {
                GameController.controller.LoadNewLevel();
            }
        }
        if (other.gameObject.tag == "levelKey")
        {
            GameController.controller.hasKey = true;
        }
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayer(1.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayer(-1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameController.controller.FlipGravity();
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            MovePlayer(0.0f);
        }
    }
}
