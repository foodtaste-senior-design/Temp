using UnityEngine;
using System.Collections;

public class StaticGreenWall : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
