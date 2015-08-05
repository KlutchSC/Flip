using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController controller;

    public bool hasKey = false;

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

    void OnLevelWasLoaded()
    {
        hasKey = false;
        Physics2D.gravity = new Vector3(0.0f, -9.8f, 0.0f);
    }

	void Update ()
    {
        Debug.Log(hasKey);
	}

    public void FlipGravity()
    {
        Physics2D.gravity = new Vector3(0.0f, (Physics2D.gravity.y * -1.0f), 0.0f);
    }

    public void LoadNewLevel()
    {
        Application.LoadLevel(curLevel+1);
    }
}
