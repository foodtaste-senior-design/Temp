using UnityEngine;
using System.Collections;
using System;

public class FullStart_ColorShiftPlatform : MonoBehaviour {

	public float x_pos;

	private Renderer render;
	private BoxCollider2D collision;

	const int HEAD_MIN = 50;
	const int HEAD_MAX = 400;

	// Use this for initialization
	void Start () {
		render = gameObject.GetComponent<Renderer> ();
		collision = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		x_pos = BodySourceView.getX ();
		setAlpha ();
		//x_pos = (x_pos + 1) % 128;
		//setColor ();	
		setCollision ();
	}

	void setAlpha() {
		Color color = render.material.color;
		if (x_pos <= 100)
			color.a = 1;
		else if (100 < x_pos && x_pos <= 200)
			color.a = 1 - ((x_pos - 100) / 100);
		else if (200 < x_pos && x_pos <= 250)
			color.a = 0;
		else if (250 < x_pos && x_pos <= 350)
			color.a = (x_pos - 250) / 100;
		else
			color.a = 1;

		render.material.color = color;
	}

	// Updates value of x_pos
	void updateXPos(float pos){
		x_pos = pos;
	}

	void setColor() {
		// Hey kids, do you like magic?
		float r, g, b;
		if (0 <= x_pos && x_pos < 4) {			// Violet -> Red
			r = 0.767f + 0.058f * x_pos;
			g = 0f;
			b = 0.5f - 0.125f * x_pos;
		} else if (4 <= x_pos && x_pos < 12) {	// Red
			r = 1f;
			g = 0f;
			b = 0f;
		} else if (12 <= x_pos && x_pos < 20) { // Red -> Orange
			r = 1f;
			g = 0.0625f * (x_pos - 12);
			b = 0f;
		} else if (20 <= x_pos && x_pos < 28) {	// Orange
			r = 1f;
			g = 0.5f;
			b = 0f;
		} else if (28 <= x_pos && x_pos < 36) {	// Orange -> Yellow
			r = 1f;
			g = 0.5f + 0.0625f * (x_pos - 28);
			b = 0f;
		} else if (36 <= x_pos && x_pos < 44) { // Yellow
			r = 1f;
			g = 1f;
			b = 0f;
		} else if (44 <= x_pos && x_pos < 52) { // Yellow -> Green
			r = 1f - 0.125f * (x_pos - 44);
			g = 1f;
			b = 0f;
		} else if (52 <= x_pos && x_pos < 76) { // Green
			r = 0f;
			g = 1f;
			b = 0f;
		} else if (76 <= x_pos && x_pos < 84) { // Green -> Blue
			r = 0f;
			g = 1f - 0.125f * (x_pos - 76);
			b = 0.125f * (x_pos - 76);
		} else if (84 <= x_pos && x_pos < 92) { // Blue
			r = 0f;
			g = 0f;
			b = 1f;
		} else if (92 <= x_pos && x_pos < 100) { // Blue -> Indigo
			r = 0.036f * (x_pos - 92);
			g = 0f;
			b = 1f - 0.0615f * (x_pos - 92);
		} else if (100 <= x_pos && x_pos < 108) { // Indigo
			r = 0.293f;
			g = 0f;
			b = 0.508f;
		} else if (108 <= x_pos && x_pos < 116) { // Indigo -> Violet
			r = 0.293f + 0.031f * (x_pos - 108);
			g = 0f;
			b = 0.508f + 0.0615f * (x_pos - 108);
		} else if (116 <= x_pos && x_pos < 124) { // Violet
			r = 0.543f;
			g = 0f;
			b = 1f;
		} else if (124 <= x_pos && x_pos < 256) { // Violet -> Red
			r = 0.543f + 0.056f * (x_pos - 124);
			g = 0f;
			b = 1f - 0.125f * (x_pos - 124);
		} else {
			throw new Exception("Unexpected x position encountered");
		}
		render.material.color = new Color (r, g, b);
	}

	void setCollision() {
		//collision.isTrigger = (52 <= x_pos && x_pos < 76);
		collision.isTrigger = (render.material.color.a == 0);
	}
}
