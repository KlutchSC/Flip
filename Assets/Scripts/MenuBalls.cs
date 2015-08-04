using UnityEngine;
using System.Collections;

public class MenuBalls : MonoBehaviour {

    Rigidbody2D myBody;

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        InvokeRepeating("GravitySwap", 1.0f, 1.0f);
	}
	
	void GravitySwap ()
    {
        GameController.controller.FlipGravity();
	}
}
