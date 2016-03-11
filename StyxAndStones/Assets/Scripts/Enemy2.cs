using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

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
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position,
		                                                   currentPoint.position,
		                                                   Time.deltaTime * moveSpeed);
		
		
		
		if (gameObject.transform.position == currentPoint.position) {
			
			pointSelection = (pointSelection + 1) % points.Length;
			currentPoint = points [pointSelection];

			// Flip direction object is facing
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;
			
		}
	}

}
