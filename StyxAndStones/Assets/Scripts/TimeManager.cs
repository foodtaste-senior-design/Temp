using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	private float startTime = 0;
	private float countingTime;

	private Text timeText;

	private bool timerRunning;

	// Use this for initialization
	void Start () {
		countingTime = startTime;
		timerRunning = false;
		timeText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if(timerRunning)
			countingTime += Time.deltaTime;

		timeText.text = "Time: " + "" + Mathf.Round(countingTime);
	}

	// Resets time to zero
	public void resetTimer(){
		countingTime = startTime;
	}

	// Starts the time
	public void startTimer(){
		timerRunning = true;
	}

}
