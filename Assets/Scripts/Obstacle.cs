﻿using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour, IRecycle {

	public Sprite[] sprites;

	public void Restart() {
		Debug.Log ("asdasdasdad");
		var renderer = GetComponent<SpriteRenderer> ();
		renderer.sprite = sprites[Random.Range (0, sprites.Length)];
	}

	public void Shutdown() {

	}
}
