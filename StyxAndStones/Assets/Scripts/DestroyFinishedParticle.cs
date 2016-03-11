using UnityEngine;
using System.Collections;

public class DestroyFinishedParticle : MonoBehaviour {

	// Destroys used particle systems to save memory

	private ParticleSystem thisParticleSystem;

	// Use this for initialization
	void Start () {
		thisParticleSystem = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (thisParticleSystem.isPlaying) 
			return;
	
		Destroy (gameObject);
	}
}
