using UnityEngine;
using System.Collections;

public class ExitPortalScript : MonoBehaviour {

    public Color32 lockedColor = new Color32();
    public Color32 exitColor = new Color32();

    public SpriteRenderer sr = new SpriteRenderer();

    void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = lockedColor;
    }
	
	void Update ()
    {
	    if (GameController.controller.hasKey == true)
        {
            sr.color = exitColor;
        }
        else
        {
            sr.color = lockedColor;
        }
	}
}
