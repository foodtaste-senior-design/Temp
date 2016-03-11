using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform wallCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;
	private bool hittingWall;

	private bool notAtEdge;
	public Transform edgeCheck;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Check if hitting a wall
		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		// Check if near edge
		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

		// If hitting a wall or at an edge turn to the opposite direction
		if (hittingWall || !notAtEdge)
			moveRight = !moveRight;

		// If moving right, face right and positive velocity 
		if (moveRight) {
			transform.localScale = new Vector3 (3f, 3f, 3f);
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		// If moving left, face left and negative velocity			 
		} else {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			transform.localScale = new Vector3(-3f, 3f, 3f);
		}
	
	}	
}
