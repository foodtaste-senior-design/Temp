using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionManager : MonoBehaviour {

	public float levelStartDelay = 3f;

	private Text transitionText;

	// Use this for initialization
	void Start () {

		// Set the text of the transition scene
		transitionText = GameObject.Find ("TransitionText").GetComponent<Text> ();
		transitionText.text = PlayerPrefs.GetString ("nextLevelText");
		Invoke ("loadLevel", levelStartDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void loadLevel(){
		// Load the next level
		Debug.Log(PlayerPrefs.GetString("sceneToLoad"));
		SceneManager.LoadScene (PlayerPrefs.GetString("sceneToLoad"));
	}
}
