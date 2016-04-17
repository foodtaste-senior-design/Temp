using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour {
	
	
	public GameObject pausePanel;
	public GameObject firstButton;
	public bool isPaused;
	public GameObject yes;
	public Canvas quitMenu;
	public Canvas PauseMenu;
	// Use this for initialization
	void Start () {
		isPaused = false;
		quitMenu = quitMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject (firstButton);
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
			isPaused = false;
		}
		else{
			isPaused=true;}
	}
	
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
	
	public void MainMenu (){
		SceneManager.LoadScene (0);
	}
	
	public void exitPress(){
		quitMenu.enabled = true;
		PauseMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject (yes);
	}
	
	public void NoPress(){
		quitMenu.enabled = false;
		PauseMenu.enabled = true;
		EventSystem.current.SetSelectedGameObject (firstButton);
	}
	public void ExitGame(){
		Application.Quit ();
	}
	
}
