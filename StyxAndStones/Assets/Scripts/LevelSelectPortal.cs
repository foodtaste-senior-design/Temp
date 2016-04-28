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
	public int unlockOrder;

	private bool inPortal;
	private bool unlocked;
	private TextMesh levelName;
	
	// Use this for initialization
	void Start () {
		inPortal = false;
		levelName = gameObject.GetComponentInChildren<TextMesh>();
		levelName.characterSize = 0f;

		//PlayerPrefs.DeleteAll ();

		if ((PlayerPrefs.GetInt ("levelsUnlocked") < unlockOrder)) {
			// Change sprite
			Sprite closedPortal = Resources.Load<Sprite> ("styx_portalClosed");
			this.GetComponent<SpriteRenderer> ().sprite = closedPortal;
			unlocked = false;

		} else {
			unlocked = true;
		}
	}


	// Update is called once per frame
	void Update () {
		
		//transform.Rotate (0,0,100*Time.deltaTime); //rotates 50 degrees per second around z axis
		// Check if player is trying to use the portal and has met the requirements
		if (inPortal && Input.GetButtonDown ("Fire1")) {
			PlayerPrefs.SetString ("nextLevelText", nextLevel);			// Store the level name to be displayed on transition
			PlayerPrefs.SetString ("sceneToLoad", nextLevel);			// Store the level name to be loaded after transition
			if (unlocked)
				SceneManager.LoadScene ("Transition");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inPortal = true;
			levelName.characterSize = 0.2f;
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inPortal = false;
			levelName.characterSize = 0f;
		}
	}
}
