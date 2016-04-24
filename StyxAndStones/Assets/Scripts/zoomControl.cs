using UnityEngine;
using System.Collections;

public class zoomControl : MonoBehaviour {
	
	public float zoomSize= 7.5f;
	private SimplePlatformController player;
	public GameObject background;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<SimplePlatformController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("z") || Input.GetButton("Fire2")) {
			if ((zoomSize < 25f) ) {
				zoomSize += 0.3f;
				// Scale camera up
				background.gameObject.transform.localScale += new Vector3 (0.0719f, 0.0719f, 0);
			}
		}
		
		else {
			if (zoomSize > 7.5f) {
				zoomSize -= 0.3f;
				// Scale background back down
				background.gameObject.transform.localScale -= new Vector3 (0.0719f, 0.0719f, 0);
			}
			
		}
			
		GetComponent<Camera>().orthographicSize = zoomSize;



	}
		
}
