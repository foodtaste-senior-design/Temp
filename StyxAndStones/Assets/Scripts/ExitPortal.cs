using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitPortal : MonoBehaviour {

	public string nextLevel;
		
	private static bool inPortal;
	private LevelManager manager;

	// Use this for initialization
	void Start () {
		inPortal = false;
		manager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Rotate (0,0,100*Time.deltaTime); //rotates 50 degrees per second around z axis
		// Check if player is trying to use the portal and has met the requirements
		if (inPortal && Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene (nextLevel);
		}
		
		if (Collectible.numCollected () == manager.totalStones) {
			Sprite openPortal = Resources.Load<Sprite> ("styx_portalOpen");
			this.GetComponent<SpriteRenderer> ().sprite = openPortal;
		} else {
			Sprite closedPortal = Resources.Load<Sprite>("styx_portalClosed");
			this.GetComponent<SpriteRenderer>().sprite = closedPortal;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		//numCollected requirement will change per level; hash this out somehow
		if (other.transform.tag == "Player" && Collectible.numCollected() == manager.totalStones) {
			inPortal = true;
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			inPortal = false;
		}
	}
	
	public static bool isInPortal() {
		return inPortal;
	}


}