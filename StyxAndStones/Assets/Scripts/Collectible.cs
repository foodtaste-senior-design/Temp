using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	private static int coinsCollected;


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
			CoinCounter.addCoin(1);				// increase coin count and add coin to CoinCounter.coins
			gameObject.SetActive(false);		// Deactivate collectible 

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
