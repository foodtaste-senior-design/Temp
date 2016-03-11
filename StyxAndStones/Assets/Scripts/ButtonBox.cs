using UnityEngine;
using System.Collections;

public class ButtonBox : MonoBehaviour {

	private bool inBox;
	private bool leverPulled;
	private static ButtonWall[] walls;

	// Use this for initialization
	void Start () {
		inBox = false;
		leverPulled = false;

		// Get all lever walls
		walls = FindObjectsOfType<ButtonWall> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && inBox) {

			if (!leverPulled){
				flip ();
				leverPulled = true;
			}	
		}

	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.transform.tag == "Player") {
			inBox = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.transform.tag == "Player") {
			inBox = false;
		}
	}

	/*
	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inBox = false;
		}
	}
	*/

	public bool triggered() 
	{
		return leverPulled;
	}

	public void reset()
	{
		leverPulled = false;
		flip ();
		for (int i = 0; i < walls.Length; i++)
			walls [i].resetWall ();
	}

	public void flip()
	{
		// Flip direction object is facing
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
