using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_zombie : Zombie {

	public float runDistance = 7f;
	public float runSpeed = 5f;

	//Местоположения относительно игрока
	float targetRange = 0f;
	float targetDirection =0f;


	//GameObject hpBar;

	void Start () {
		//hpBar = transform.Find ("HPBar").gameObject;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		conditions = GetComponent<Conditions> ();
		damage = GetComponent<Damage> ();
	}

	void Update () {

		if (!idle) {
			
			if (CanMove()) {

				//Определение местоположения игрока
				targetRange = Mathf.Abs (transform.position.x - target.transform.position.x);
				targetDirection = Mathf.Sign (transform.position.x - target.transform.position.x);
				flipParam = input;

				//Если юнит не находится в состоянии атаки
				if (!conditions.attack) {
					//Если расстояние до цели меньше указанного и юнит стоит лицом к цели
					if (targetRange < (attackRange - 0.3f) && ((targetDirection < 0f && direction > 0f) || (targetDirection > 0f && direction < 0f))) {
						//Остановиться и атаковать
						Attack ();
					} else {
						SetTargetSpeedAndDirection ();
					}
				}
			}

			rb.velocity = new Vector2 (input * moveSpeed, rb.velocity.y);
			anim.SetFloat ("speed", Mathf.Abs (input * moveSpeed));
		}
	}

	//Нанести урон
	public override void Attack () {
		input = 0f;
		if (!conditions.attack) {
			conditions.attack = true;
			anim.SetTrigger ("attack");
		}
	}

	void SetTargetSpeedAndDirection () {
		//Если дистанция до цели меньше расстояния рывка
		if (targetRange < runDistance) {
			//Перейти на бег
			conditions.SetMovespeed (runSpeed);
		} else
			//Иначе - идти пешком
			conditions.SetMovespeed (conditions.defaultMovespeed);
		//Двигаться в сторону игрока
		input = -targetDirection;
	}
		
	//Проверка на возможность что-либо делать
	public override bool CanMove ()
	{
		return base.CanMove ();
	}

	public override bool CanAttack ()
	{
		return base.CanAttack ();
	}
}
