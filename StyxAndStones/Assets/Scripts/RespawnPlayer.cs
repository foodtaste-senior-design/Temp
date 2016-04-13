using UnityEngine;
using System.Collections;

public class RespawnPlayer : MonoBehaviour {

	public LevelSelect levelManager;
	public AudioSource deathSFX;
	
	// Use this for initialization
	void Start () {
		// Find levelManager in scene
		levelManager = FindObjectOfType<LevelSelect> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Player") {
			deathSFX.Play ();
			levelManager.RespawnPlayer();
		}
	}
}
