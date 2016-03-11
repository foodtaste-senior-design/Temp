using UnityEngine;
using System.Collections;

public class ButtonWall : MonoBehaviour {
	private ButtonBox lever;

	// Use this for initialization	
	void Start () {
		lever = FindObjectOfType<ButtonBox> ();
	}
	
	// Update is called once per frame
	void Update () {
		/* for colored walls
		if (ButtonBox.isInBox ()) {
			if (gameObject.GetComponent<Renderer> ().material.color == Color.grey) {
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				collision.isTrigger = true;
			}
		}
		*/
		if (lever.triggered ())
			gameObject.SetActive(false);
		
	}

	public void resetWall(){
		gameObject.SetActive (true);
	}
}
