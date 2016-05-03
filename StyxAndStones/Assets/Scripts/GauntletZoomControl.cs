using UnityEngine;
using System.Collections;

public class GauntletZoomControl : MonoBehaviour {
	
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
			Time.timeScale = 0.0f;
			if ((zoomSize < 35f) ) {
                // Scale camera up

                zoomSize += 0.45f;
				background.gameObject.transform.localScale += new Vector3(0.12f, 0.12f, 0); ;
                background.gameObject.transform.position += new Vector3(0.2f, -0.35f, 0); ;
                GetComponent<Camera>().transform.position += new Vector3(0.2f, -0.35f, 0);
                
             
            }
		}
		
		else {
			if (zoomSize > 7.5f) {
                // Scale background back down
                zoomSize -= 0.45f;
				background.gameObject.transform.localScale -= new Vector3(0.12f, 0.12f, 0); 
                background.gameObject.transform.position -= new Vector3(0.2f, -0.35f, 0); ;

                GetComponent<Camera>().transform.position -= new Vector3(0.2f, -0.35f, 0);
            }
			
		}
			
		GetComponent<Camera>().orthographicSize = zoomSize;



	}
		
}
