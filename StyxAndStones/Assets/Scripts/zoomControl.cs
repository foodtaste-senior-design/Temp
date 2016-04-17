using UnityEngine;
using System.Collections;

public class zoomControl : MonoBehaviour {
	
	public float zoomSize= 7.5f;

	public GameObject background;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("z") || Input.GetButton("Fire2")) {
			if (zoomSize < 25f) {
				zoomSize += 0.1f;

				//if (background.gameObject.transform.localScale.magnitude < new Vector3(6.2f,6.2f,0).magnitude){
					background.gameObject.transform.localScale += new Vector3 (0.029f, 0.029f, 0);
				//}
			}
		}
		
		else {
			if (zoomSize > 7.5f) {
				zoomSize -= 0.1f;
				//if (background.gameObject.transform.localScale.magnitude > new Vector3(2,2,0).magnitude){
					background.gameObject.transform.localScale -= new Vector3 (0.029f, 0.029f, 0);
				//}
			}
			
		}
			
		GetComponent<Camera>().orthographicSize = zoomSize;

	}


}
