using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	private static int coinsCollected;

	public AudioSource pickupSFX;
	public GameObject particleFX;

	// Use this for initialization
	void Start () {
		coinsCollected = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.transform.tag == "Player") {
			coinsCollected++;
			// Play pickup sfx
			pickupSFX.Play ();
			// Start particle effect
			Instantiate(particleFX,gameObject.transform.position,gameObject.transform.rotation);
			// increase coin count and add coin to CoinCounter.coins
			CoinCounter.addCoin(1);
			// Deactivate collectible
			gameObject.SetActive(false);		 

		}
	}

	// Resets collectible
	public void resetCollectible(){
		coinsCollected = 0;
		gameObject.SetActive (true);

	}

	public static int numCollected() {
		return coinsCollected;
	}

}
