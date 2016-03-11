using UnityEngine;
using System.Collections;

public class HeadPlatform : MonoBehaviour {

	public GameObject platform;
	public Transform[] points;
	//public Transform platformMin;				// The leftmost point to which the platform should move to
	//public Transform platformMax;				// The rightmost point to which the platform should move to
	private float kinectMin_x = 0;				// The leftmost point to which the players head should move
	private float kinectMax_x = 400;			// The rightmost point to which the players head should move
	private float kinectMin_y = 70;				// The uppermost point to which the players head should move
	private float kinectMax_y = 310;			// The lowermost point to which the players head should move

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (BodySourceView.isBodyTracked ()) {
			Debug.Log (BodySourceView.getY ());
			float head_x = BodySourceView.getX();
			float head_y = BodySourceView.getY();

			if (head_x < kinectMin_x)
				head_x = kinectMin_x;
			if (head_x > kinectMax_x)
				head_x = kinectMax_x;
			if (head_y < kinectMin_y)
				head_y = kinectMin_y;
			if (head_y > kinectMax_y)
				head_y = kinectMax_y;

			float new_X = points[0].position.x + (((head_x-kinectMin_x)/(kinectMax_x-kinectMin_x)) * (points[1].position.x-points[0].position.x));
			float new_Y = points[0].position.y + (((head_y-kinectMin_y)/(kinectMax_y-kinectMin_y)) * (points[1].position.y-points[0].position.y));

			platform.transform.position = new Vector2 (new_X, new_Y);
			/*
			float platformMin_x = platformMin.position.x;	// Minimum x value for platform
			float platformMax_x = platformMax.position.x;	// Maximum x value for platform
			float head_x = BodySourceView.getX();			// Position of head from Kinect

			float relativeKinectDistance = (head_x - kinectMin_x)/(kinectMax_x - kinectMin_x);
			float platform_x = (relativeKinectDistance * (platformMax_x - platformMin_x)) + platformMin_x;							// New x value for platform
			platform.transform.position = new Vector3 (platform_x, platform.transform.position.y, platform.transform.position.z);
			*/
		}
	}
}
