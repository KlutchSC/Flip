using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    SpriteRenderer myRender;

    public Color32 color_01 = new Color32();
    public Color32 color_02 = new Color32();
    public Color32 color_03 = new Color32();
    public Color32 color_04 = new Color32();
    public Color32 color_05 = new Color32();

	void Start ()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = color_01;
	}
	
	void Update () 
    {
	
	}
}
