using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
	
	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float levelStartDelay = 3f;
	public float respawnDelay;
	
	// Is player alive or in process of respawning 
	private bool playerAlive;
	
	private SimplePlatformController player;
	private float gravityStore;

	// Use this for initialization
	void Start () {
		
		// Find game objects in scene
		player = FindObjectOfType<SimplePlatformController> ();
		
		playerAlive = true;

	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
		
		
		Instantiate (deathParticle, player.transform.position, player.transform.rotation);								// Instantiate death particle effect when player dies
		playerAlive = false;																							// Prevent player from being killed again
		player.enabled = false;																							// Disable player controls
		player.GetComponentInChildren<Renderer> ().enabled = false; 													// Make player disappear
		player.background.GetComponent<Renderer> ().enabled = true;
		yield return new WaitForSeconds (respawnDelay);																	// Delay between respawn and death																						// Reset coins and coin count
		player.transform.position = currentCheckpoint.transform.position;												// Respawn player at checkpoint
		player.enabled = true;																							// Enable player controls
		player.GetComponentInChildren<Renderer> ().enabled = true;														// Make player reappear
		playerAlive = true;																								// Now the player can die
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);		// Instantiate respawn particle effect when player respawns
	}
	
	// Return value of playerAlive
	public bool getPlayerAlive(){
		return playerAlive;
	}

}
