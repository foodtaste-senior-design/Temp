using UnityEngine;
using System.Collections;

public class LevelCompleteText : MonoBehaviour {

	private static bool over;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
		over = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (ExitPortal.isInPortal()) {
			GetComponent<Renderer>().enabled = true;
			over = true;
		}
	}

	public static bool gameOver ()
	{
		return over;
	}

}
