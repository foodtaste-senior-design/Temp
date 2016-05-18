using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SquatCounter : MonoBehaviour {

	private float[] hips;
	private float[] knees;
	private float squatCount;

	bool squatting;
	bool textOn;

	private Text squatText;

	// Use this for initialization
	void Start () {
		squatting = true;
		squatCount = 0;
		squatText = GetComponent<Text> ();
		squatText.enabled = false;
		textOn = false;
	}
	
	// Update is called once per frame
	void Update () {

		// Show and hide squat count
		if(Input.GetButtonDown("Fire3")){
			textOn = !textOn;
		} 
/*		else if (Input.GetButton("Fire3") && textOn){
			squatText.enabled = false;
			textOn = false;
		}
*/
		hips = BodySourceView.getHips ();
		knees = BodySourceView.getKnees ();

		float leftHipY = hips [1];
		float rightHipY = hips [3];
		float leftKneeY = knees [1];
		float rightKneeY = knees [3];

		// Distance between hips and knees
		float squatLeft = Mathf.Abs (leftHipY - leftKneeY);
		float squatRight = Mathf.Abs (rightHipY - rightKneeY);

		// If player was not squating and now is increment counter
		if (!squatting) {
			if (squatLeft < 25 && squatRight < 25) {
				squatCount++;
				squatting = true;
			}
		}

		// Check if player has stopped squatting 
		if (squatting) {
			if (squatLeft > 35 && squatRight > 35) {
				squatting = false;
			}
		}

		squatText.text = squatCount.ToString();
		squatText.enabled = textOn;
		Debug.Log (squatCount);
	}
}
