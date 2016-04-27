/* 
 * This class is similar to ExitPortal but does not use static variables 
 * since there will be more than one portal in the level_select scene where 
 * this is used.
*/

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
 
public class LevelSelectPortal : MonoBehaviour {
	
	public string nextLevel;

	private bool inPortal;
	
	// Use this for initialization
	void Start () {
		inPortal = false;
	}


	// Update is called once per frame
	void Update () {
		
		//transform.Rotate (0,0,100*Time.deltaTime); //rotates 50 degrees per second around z axis
		// Check if player is trying to use the portal and has met the requirements
		if (inPortal && Input.GetButtonDown ("Fire1")) {
			PlayerPrefs.SetString ("nextLevelText", nextLevel);			// Store the level name to be displayed on transition
			PlayerPrefs.SetString ("sceneToLoad", nextLevel);			// Store the level name to be loaded after transition
			SceneManager.LoadScene ("Transition");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		//numCollected requirement will change per level; hash this out somehow
		if (other.transform.tag == "Player") {
			inPortal = true;
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inPortal = false;
		}
	}
}
