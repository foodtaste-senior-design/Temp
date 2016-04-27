using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.EventSystems;

public class PauseManager : MonoBehaviour {


	public GameObject pausePanel;
	public GameObject ResumeButton;
	public GameObject RestartButton;
	public GameObject MMButton;
	public GameObject QuitButton;
	public GameObject YesButton;

	public bool isPaused;

	public Canvas quitMenu;
	public Canvas PauseMenu;

	public Image ResumeIcon;
	public Image RestartIcon;
	public Image MMIcon;
	public Image QuitIcon;

	// Use this for initialization
	void Start () {
		isPaused = false;
		quitMenu = quitMenu.GetComponent<Canvas> ();
		quitMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject (ResumeButton);

		ResumeIcon.enabled = false;
		RestartIcon.enabled = false;
		ResumeIcon.enabled = false;
		MMIcon.enabled = false;
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

		if (EventSystem.current.currentSelectedGameObject == ResumeButton)
		{
			ResumeIcon.enabled = true;
		}
		else { ResumeIcon.enabled = false; }

		if (EventSystem.current.currentSelectedGameObject == RestartButton)
		{
			RestartIcon.enabled = true;
		}
		else { RestartIcon.enabled = false; }

		if (EventSystem.current.currentSelectedGameObject == MMButton)
		{
			MMIcon.enabled = true;
		}
		else { MMIcon.enabled = false; }

		if (EventSystem.current.currentSelectedGameObject == QuitButton)
		{
			QuitIcon.enabled = true;
		}
		else { QuitIcon.enabled = false; }
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
		MMButton.SetActive(false);
		EventSystem.current.SetSelectedGameObject (YesButton);
	}

	public void NoPress(){
		quitMenu.enabled = false;
		PauseMenu.enabled = true;
		MMButton.SetActive(true);
		EventSystem.current.SetSelectedGameObject (ResumeButton);
	}
	public void ExitGame(){
		Application.Quit ();
	}

}
