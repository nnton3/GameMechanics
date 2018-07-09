using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour {

	public float health = 0f;
	public float armor = 0f;
	public float attack = 0f;
	public float attackSpeed = 0f;
	public float attackRange = 1f;

	public float moveSpeed;
	public float impulsePower;
	[HideInInspector]
	public float input = 0f;
	[HideInInspector]
	public Rigidbody2D rb;
	[HideInInspector]
	public Animator anim;
	[HideInInspector]
	public Damage damage;
	[HideInInspector]
	public Conditions conditions;
	[HideInInspector]
	public float direction = 1f;
	[HideInInspector]
	public float flipParam = 0f;


	public virtual void Attack () {
		
	}

	//Проверка на возможность двигаться
	public virtual bool CanMove() {
		return (conditions.alive && !conditions.stun);
	}

	//Проверка на возможность атаковать
	public virtual bool CanAttack() {
		return (!conditions.attack && !conditions.stun);
	}

	//Зарегистрироваться в родительском стаке врагов
	public DangerArea myStack;
	public virtual void RegistrationInStack () {
		myStack = GetComponentInParent<DangerArea> ();
		myStack.AddEnemie (this);
	}
}
