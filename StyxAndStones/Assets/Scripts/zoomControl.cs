﻿using UnityEngine;
using System.Collections;

public class zoomControl : MonoBehaviour {
	public float zoomSize= 7.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("z") || Input.GetButton("Fire2")) {
			if (zoomSize <25f)
				zoomSize += 0.1f;
		}
		
		else {
			if (zoomSize >7.5f)
				zoomSize -= 0.1f;
		}
		
		GetComponent<Camera>().orthographicSize = zoomSize;

	}


}
