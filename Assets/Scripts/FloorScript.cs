using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

    SpriteRenderer myRender;

    public bool isFloor;
    public bool isFire;

    public Color32 floorColor = new Color32();
    public Color32 bgColor = new Color32();
    public Color32 fireColor = new Color32();

	void Start ()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (isFloor)
        {
            sr.color = floorColor;
        }
        else if (isFire)
        {
            sr.color = fireColor;
        }
        else
        {
            sr.color = bgColor;
        }
	}
	
	void Update () 
    {
	
	}
}
