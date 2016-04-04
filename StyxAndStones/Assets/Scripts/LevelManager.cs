using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	private SimplePlatformController player;
	public ButtonBox lever;
	private float gravityStore;

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float totalStones;

	public float respawnDelay;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<SimplePlatformController> ();
		lever = FindObjectOfType<ButtonBox> ();
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
		player.enabled = false;																							// Disable player controls
		player.GetComponentInChildren<Renderer> ().enabled = false; 													// Make player disappear
		yield return new WaitForSeconds (respawnDelay);																	// Delay between respawn and death
		CoinCounter.loseCoins();																						// Reset coins and coin count
		player.transform.position = currentCheckpoint.transform.position;												// Respawn player at checkpoint
		player.enabled = true;																							// Enable player controls
		player.GetComponentInChildren<Renderer> ().enabled = true;														// Make player reappear
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);		// Instantiate respawn particle effect when player respawns
		lever.reset ();																									// Reset triggered levers
	}
}
