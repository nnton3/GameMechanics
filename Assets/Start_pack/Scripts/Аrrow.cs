﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Аrrow : Unit {

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		StartCoroutine ("Timer");
	}

	void Update () {
		rb.velocity = new Vector2 (input * moveSpeed, rb.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D target) {
		if (target.CompareTag ("Enemy")) {
			target.GetComponent<Damage> ().DefaultDamage(attack, direction);
			Destroy (gameObject);
		}
	}

	public void SetDirection (float direction) {
		flipParam = direction;
		input = direction;
	}

	IEnumerator Timer() {
		yield return new WaitForSeconds (3f);
		Destroy (gameObject);
	}
}
