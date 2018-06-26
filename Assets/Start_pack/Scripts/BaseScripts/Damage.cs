using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

	[HideInInspector]
	public Unit unit;
	[HideInInspector]
	public Conditions conditions;
	[HideInInspector]
	public Animator anim;

	void Start() {
		unit = GetComponent<Unit> ();
		conditions = GetComponent<Conditions> ();
		anim = GetComponent<Animator> ();
	}

	//Стандартный удар
	public virtual void DefaultDamage(float damage, float direction) {
		unit.health -= damage;
	}

	//Критический урон
	public virtual void CriticalDamage (float damage, float direction, float criticalScale) {
		unit.health -= (damage * criticalScale);
	}

	//Сбивание с ног
	public virtual void Push(float pushPower ) {
		
	}
}
