using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController controller;

    public bool hasKey;

    public int nextLevel;
    public int curLevel;

    void Awake()
    {
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

	void Start()
    {
        curLevel = Application.loadedLevel;
	}

	void Update ()
    {
        Debug.Log(Application.loadedLevel);
	}

    public void FlipGravity()
    {
        Physics2D.gravity = new Vector3(0.0f, (Physics2D.gravity.y * -1.0f), 0.0f);
    }

    public void LoadNewLevel()
    {
        if (hasKey == true)
        {
            Application.LoadLevel(nextLevel);
        }
    }
}
