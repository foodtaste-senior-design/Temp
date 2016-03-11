using UnityEngine;
using System.Collections;
using System;

public class MovingPlatform : MonoBehaviour {

	public GameObject platform;
	public float moveSpeed;
	public Transform[] points;
	public int pointSelection;
	
	private Transform currentPoint;

	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
	}
	
	// Update is called once per frame
	void Update () {
		platform.transform.position = Vector3.MoveTowards (platform.transform.position,
		                                                   currentPoint.position,
		                                                   Time.deltaTime * moveSpeed);



			if (platform.transform.position == currentPoint.position) {

				pointSelection = (pointSelection + 1) % points.Length;
				currentPoint = points [pointSelection];

			}
	}

}
