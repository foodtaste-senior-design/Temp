using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
	public AudioSource deathSFX;

	// Use this for initialization
	void Start () {
		// Find levelManager in scene
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player" && levelManager.getPlayerAlive()) {
			deathSFX.Play ();
			levelManager.RespawnPlayer();
		}
	}
}
