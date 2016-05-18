using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {


	public ButtonBox lever;

	public GameObject currentCheckpoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float totalStones;
	public float levelStartDelay = 3f;
	public float respawnDelay;
	public float deathCount;

	// Texts displayed at start of level
	public string startText;

	// Is player alive or in process of respawning 
	private bool playerAlive;

	private SimplePlatformController player;
	private float gravityStore;

	private TimeManager time; 
	private GameObject transitionImage;
	private Text levelText;
	private Text deathCountText;

	// Use this for initialization
	void Start () {



		// Set text for level transition
		PlayerPrefs.SetString ("nextLevelText", "Level Complete");
		PlayerPrefs.SetString ("sceneToLoad", "level_select");

		// Find game objects in scene
		player = FindObjectOfType<SimplePlatformController> ();
		lever = FindObjectOfType<ButtonBox> ();
		time = FindObjectOfType<TimeManager> ();

		// Start timer
		time.startTimer ();

		// Set Death Counter
		deathCount = 0;
		deathCountText = GameObject.Find ("DeathCount").GetComponent<Text> ();
		deathCountText.text = "" + deathCount;


		playerAlive = true;

		// Set next level name


		// Display and hide transition screen
		//startTransition ();
	}
	

	// Update is called once per frame
	void Update () {
	
	}

	/*// Displays Level name
	void startTransition(){
		transitionImage = GameObject.Find ("TransitionImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = startText;
		transitionImage.SetActive (true);
		Invoke ("hideTransitionImage", levelStartDelay);
		
	}

	// Hides level transition screen
	private void hideTransitionImage(){
		transitionImage.GetComponent<Image> ().color = Color.Lerp(transitionImage.GetComponent<Image>().color, Color.clear, 1.5f * Time.deltaTime);
		transitionImage.SetActive(false);

	}*/

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
		deathCount += 1;																								// Update death counter
		deathCountText.text = "" + deathCount;
		yield return new WaitForSeconds (respawnDelay);																	// Delay between respawn and death
		CoinCounter.loseCoins();																						// Reset coins and coin count
		player.transform.position = currentCheckpoint.transform.position;												// Respawn player at checkpoint
		player.enabled = true;																							// Enable player controls
		player.GetComponentInChildren<Renderer> ().enabled = true;														// Make player reappear
		playerAlive = true;																								// Now the player can die
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);		// Instantiate respawn particle effect when player respawns
		if (lever != null)
			lever.reset ();																								// Reset triggered levers
	}

	// Return value of playerAlive
	public bool getPlayerAlive(){
		return playerAlive;
	}

}
