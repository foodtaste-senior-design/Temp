using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Canvas quitMenu;
	public Button startText;
	public Button exitText;
	public Canvas levelSelection;
	//public Canvas setting;
	// Use this for initialization
	void Start () {
		//setting = setting.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		levelSelection = levelSelection.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		levelSelection.enabled = false;
		//setting.enabled = false;
	}
	
	// Update is called once per frame
	public void ExitPress(){
		
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
		levelSelection.enabled = false;
		//setting.enabled = false;
		
	}
	public void	NoPress(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		levelSelection.enabled = false;
		//setting.enabled = false;
	}
	
	public void selectLvl(){
		levelSelection.enabled = true;
		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;

		//setting.enabled = false;
		
	}
	
	public void returnMenu(){
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		levelSelection.enabled = false;
		//setting.enabled = false;	
	}
	
	public void gameSetting(){
		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		levelSelection.enabled = false;
		//setting.enabled = true;
	}
	
	
	
	public void StartLevel(){
		Application.LoadLevel (2);
	}
	public void ExitGame(){
		Application.Quit ();
	}
}
