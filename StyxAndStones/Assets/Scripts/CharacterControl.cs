using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{
    public Platform Platform
    {
        get
        {
            throw new System.NotImplementedException();
        }

        set
        {
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (LevelCompleteText.gameOver ()) {
			GetComponent<Renderer>().enabled = false;
			SimplePlatformController.stopMoving();
		}
	}

}
