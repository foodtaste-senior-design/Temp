using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class menuScript : MonoBehaviour
{
	public Canvas quitMenu;
	//public Canvas settingMenu;
	public Button startText;
	public Button exitText;
	public Button settingText;

	public GameObject yesButton;
	public GameObject playButton;
	public GameObject CalibrationButton;
	public GameObject ExitButton;

	public Image PlayIcon;
	public Image CalibrationIcon;
	public Image ExitIcon;


	// Use this for initialization
	void Start()
	{
		//settingMenu = settingMenu.GetComponent<Canvas> ();
		quitMenu = quitMenu.GetComponent<Canvas>();

		startText = startText.GetComponent<Button>();
		exitText = exitText.GetComponent<Button>();
		settingText = settingText.GetComponent<Button>();

		PlayIcon = PlayIcon.GetComponent<Image>();
		CalibrationIcon = CalibrationIcon.GetComponent<Image>();
		ExitIcon = ExitIcon.GetComponent<Image>();

		quitMenu.enabled = false;
		//settingMenu.enabled = false;



		CalibrationIcon.enabled = false;
		PlayIcon.enabled = false;
		ExitIcon.enabled = false;

		EventSystem.current.SetSelectedGameObject(playButton);


	}
	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == playButton)
		{
			PlayIcon.enabled = true;
		}
		else { PlayIcon.enabled = false; }


		if (EventSystem.current.currentSelectedGameObject == CalibrationButton)
		{
			CalibrationIcon.enabled = true;
		}
		else { CalibrationIcon.enabled = false; }

		if (EventSystem.current.currentSelectedGameObject == ExitButton)
		{
			ExitIcon.enabled = true;
		}
		else { ExitIcon.enabled = false; }

		if (Input.GetButtonDown("RightStickClick") && Input.GetButtonDown("LeftStickClick")){
			PlayerPrefs.DeleteAll();
		}

	}

	// Update is called when pressed
	public void ExitPress()
	{
		/*
		quitMenu.enabled = true;

		startText.enabled = false;
		exitText.enabled = false;
		settingText.enabled = false;
		//settingMenu.enabled = false;
		EventSystem.current.SetSelectedGameObject(yesButton);
		*/

		Application.Quit ();
	}



	public void returnMenu()
	{
		startText.enabled = true;
		exitText.enabled = true;
		settingText.enabled = true;

		quitMenu.enabled = false;
		//settingMenu.enabled = false;

		EventSystem.current.SetSelectedGameObject(playButton);

	}





	public void StartLevel()
	{
		Application.LoadLevel(3);
	}
	public void ExitGame()
	{
		Application.Quit();
	}
	public void calibration()
	{
		Application.LoadLevel(4);
	}
}
