using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Canvas settingMenu;
	public Button startText;
	public Button exitText;
	public Button settingText;
	public GameObject yes;
	public GameObject play;
	public GameObject exit;
	// Use this for initialization
	void Start () {
		settingMenu = settingMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		settingText = settingText.GetComponent<Button> ();
		
		quitMenu.enabled = false;
		settingMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject (play);
		
		
	}

	// Update is called when pressed
	public void ExitPress(){
		quitMenu.enabled = true;
		
		startText.enabled = false;
		exitText.enabled = false;
		settingText.enabled = false;
		settingMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject (yes);
		
		
	}
	
	
	
	public void	returnMenu(){
		startText.enabled = true;
		exitText.enabled = true;
		settingText.enabled = true;
		
		quitMenu.enabled = false;
		settingMenu.enabled = false;
		
		EventSystem.current.SetSelectedGameObject (play);
		
	}
	
	public void gamesettingMenu(){
		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		settingText.enabled = false;
		
		settingMenu.enabled = true;
		
		EventSystem.current.SetSelectedGameObject (exit);
	}
	
	
	
	public void StartLevel(){
		Application.LoadLevel (3);
	}
	public void ExitGame(){
		Application.Quit ();
	}
	public void calibration(){
		Application.LoadLevel (4);
	}
}
