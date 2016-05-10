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
}
	
	// Update is called once per frame
	void Update () {
        Sprite nextText;

        if (Input.GetButtonDown("A") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateDistance")
        {
            nextText = Resources.Load<Sprite>("styx_calibrateMaxHeight");
            this.GetComponent<SpriteRenderer>().sprite = nextText;
        }

        if (Input.GetButtonDown("Y") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateMaxHeight")
        {
            setYMin();

            nextText = Resources.Load<Sprite>("styx_calibrateMinHeight");
            this.GetComponent<SpriteRenderer>().sprite = nextText;
        }

        if (Input.GetButtonDown("A") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateMinHeight")
        {
            setYMax();

            nextText = Resources.Load<Sprite>("styx_calibrateMaxLeft");
            this.GetComponent<SpriteRenderer>().sprite = nextText;
        }

        if (Input.GetButtonDown("X") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateMaxLeft")
        {
            setXMin();

            nextText = Resources.Load<Sprite>("styx_calibrateMaxRight");
            this.GetComponent<SpriteRenderer>().sprite = nextText;
        }

        if (Input.GetButtonDown("B") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateMaxRight")
        {
            setXMax();

            if (max_X - min_X >= 200 && max_Y - min_Y >= 125)
            {
                nextText = Resources.Load<Sprite>("styx_calibrateSaved");
                this.GetComponent<SpriteRenderer>().sprite = nextText;
            }
            else if (max_X - min_X >= 200 && max_Y - min_Y < 125)
            {
                nextText = Resources.Load<Sprite>("styx_calibrateVerticalError");
                this.GetComponent<SpriteRenderer>().sprite = nextText;
            }
            else if (max_X - min_X < 200 && max_Y - min_Y >= 125)
            {
                nextText = Resources.Load<Sprite>("styx_calibrateHorizontalError");
                this.GetComponent<SpriteRenderer>().sprite = nextText;
            }
            else
            {
                nextText = Resources.Load<Sprite>("styx_calibrateDistanceError");
                this.GetComponent<SpriteRenderer>().sprite = nextText;
            }
        }

        if (Input.GetButtonDown("Start") && this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateSaved")
        {
            SceneManager.LoadScene("StartMenu");
        }

        if (Input.GetButtonDown("A") && (this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateVerticalError" || this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateHorizontalError" || this.GetComponent<SpriteRenderer>().sprite.name == "styx_calibrateDistanceError"))
        {
            nextText = Resources.Load<Sprite>("styx_calibrateDistance");
            this.GetComponent<SpriteRenderer>().sprite = nextText;
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
}
