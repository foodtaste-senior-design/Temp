using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Calibration : MonoBehaviour {

	public float min_X;
	public float max_X;
	public float min_Y;
	public float max_Y;

	// Use this for initialization
	void Start () {
		Debug.Log (PlayerPrefs.GetFloat ("XMin") + " " + PlayerPrefs.GetFloat ("XMax") + " " + PlayerPrefs.GetFloat ("YMin") + " " + PlayerPrefs.GetFloat ("YMax"));

		min_X = PlayerPrefs.GetFloat ("XMin");

		max_X = PlayerPrefs.GetFloat ("XMax");
		if (PlayerPrefs.GetFloat ("XMax") == 0) {
			max_X = 400;
			PlayerPrefs.SetFloat ("XMax", max_X);
		}

		min_Y = PlayerPrefs.GetFloat ("YMin");
		if (PlayerPrefs.GetFloat ("YMin") == 0) {
			min_Y = 70;
			PlayerPrefs.SetFloat ("YMin", min_Y);
		}

		max_Y = PlayerPrefs.GetFloat ("YMax");
		if (PlayerPrefs.GetFloat ("YMax") == 0) {
			max_Y = 310;
			PlayerPrefs.SetFloat ("YMax", max_Y);
		}

		/* do this if Floats are null
		PlayerPrefs.SetFloat ("XMin", 0);
		PlayerPrefs.SetFloat ("XMax", 400);
		PlayerPrefs.SetFloat ("YMin", 70);
		PlayerPrefs.SetFloat ("YMax", 310);
		*/

		gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("A")) {
			setYMax ();
			gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
		}
		if (Input.GetButtonDown ("B")) {
			setXMax ();
			gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
		}
		if (Input.GetButtonDown ("X")) {
			setXMin ();
			gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
		}
		if (Input.GetButtonDown ("Y")) {
			setYMin();
			gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
		}
		if (Input.GetButtonDown ("Start")) {
			confirmCalibration();
		}
	}

	void setXMin () {
		if (BodySourceView.getX () > 0) {
			min_X = BodySourceView.getX ();
			PlayerPrefs.SetFloat ("XMin", min_X);
		} else {
			min_X = 0;
			PlayerPrefs.SetFloat ("XMin", 0);
		}
	}

	void setXMax () {
		if (BodySourceView.getX () < 400) {
			max_X = BodySourceView.getX ();
			PlayerPrefs.SetFloat ("XMax", max_X);
		}
		else {
			max_X = 400;
			PlayerPrefs.SetFloat ("XMax", min_X);
		}
	}

	void setYMin () {
		if (BodySourceView.getY () > 70) {
			min_Y = BodySourceView.getY ();
			PlayerPrefs.SetFloat ("YMin", min_Y);
		} else {
			min_Y = 70;
			PlayerPrefs.SetFloat("YMin", 70);
		}
	}

	void setYMax () {
		if (BodySourceView.getY () < 310) {
			max_Y = BodySourceView.getY ();
			PlayerPrefs.SetFloat ("YMax", max_Y);
		} else {
			max_Y = 310;
			PlayerPrefs.SetFloat("YMax", max_Y);
		}
	}

	void confirmCalibration () {
		if (max_X - min_X >= 200 && max_Y - min_Y >= 125)
			SceneManager.LoadScene ("StartMenu");
		else {
			StartCoroutine ( LogError() );
		}
	}

	IEnumerator LogError () {
		gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00") + "\n<color=orange>Values not sufficiently far apart.</color>";
		yield return new WaitForSeconds (2);
		gameObject.GetComponent<TextMesh> ().text = "X-min: " + min_X.ToString ("0.00") + "\nX-max: " + max_X.ToString ("0.00") + "\nY-min: " + min_Y.ToString ("0.00") + "\nY-max: " + max_Y.ToString ("0.00");
	}
}
