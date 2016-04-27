using UnityEngine;
using System.Collections;

public class ButtonBox : MonoBehaviour {

	private bool inBox;
	private bool leverPulled;
	private static ButtonWall[] walls;

	public AudioSource buttonSFX;
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
				buttonSFX.Play ();
				//flip ();
				leverPulled = true;
			}	
		}

		if (leverPulled) {
			Sprite openPortal = Resources.Load<Sprite> ("lever-on");
			this.GetComponent<SpriteRenderer> ().sprite = openPortal;
		} else {
			Sprite closedPortal = Resources.Load<Sprite>("lever-off");
			this.GetComponent<SpriteRenderer>().sprite = closedPortal;
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

	// Resets the button and button walls
	public void reset()
	{
		// Check if the button has actually been flipped
		if (leverPulled == true) {
			leverPulled = false;
			//flip ();
			for (int i = 0; i < walls.Length; i++)
				walls [i].resetWall ();
		}
	}

	public void flip()
	{
		// Flip direction object is facing
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
