using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerArea : MonoBehaviour {

	alert zombieAlert;
	idle zombieIdle;
	List<IReaction<GameObject>> zombies = new List<IReaction<GameObject>>();

	void Start () {
		foreach (IReaction<GameObject> zombie in zombies) {
			zombieAlert += zombie.Chase;
		}

		foreach (IReaction<GameObject> zombie in zombies) {
			zombieIdle += zombie.Idle;
		}
	}

	public void AddZombie(IReaction<GameObject> newZombie) {
		zombies.Add (newZombie);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("enter");
			zombieAlert (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.CompareTag ("Player")) {
			zombieIdle ();
		}
	}
}
