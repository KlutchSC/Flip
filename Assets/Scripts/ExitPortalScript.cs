using UnityEngine;
using System.Collections;

public class ExitPortalScript : MonoBehaviour {

    public Color32 lockedColor = new Color32();
    public Color32 exitColor = new Color32();

    public SpriteRenderer sr = new SpriteRenderer();
    public ParticleSystem ps = new ParticleSystem();

    void Start ()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        ps = gameObject.GetComponent<ParticleSystem>();
        sr.color = lockedColor;
        ps.enableEmission = false;
    }
	
	void Update ()
    {
	    if (GameController.controller.hasKey == true)
        {
            sr.color = exitColor;
            ps.enableEmission = true;
        }
        else
        {
            sr.color = lockedColor;
            ps.enableEmission = true;
        }
	}
}
