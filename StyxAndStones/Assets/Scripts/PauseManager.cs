using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour {
	
	
	public GameObject pausePanel;
	public bool isPaused;
	// Use this for initialization
	void Start () {
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}
		
		if (Input.GetButtonDown ("Cancel")) {
			switchPause();
		}
		
	}
	void PauseGame (bool state){
		if (state) {
			Time.timeScale = 0.0f;}
		else {
			Time.timeScale=1.0f;}
		
		pausePanel.SetActive(state);
	}
	public void switchPause(){
		if (isPaused) {
			isPaused = false;}
		else{
			isPaused=true;}
	}
	
	public void Restart(){
		Application.LoadLevel (2);
	}
	
	public void MainMenu (){
		Application.LoadLevel (0);
	}
	public void ExitGame(){
		Application.Quit ();
	}
}
