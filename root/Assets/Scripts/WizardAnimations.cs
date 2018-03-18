using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour {

	public const string IDLE	= "Wizard_Idle";
	public const string RUN		= "Wizard_Run";
	public const string ATTACK	= "Wizard_Attack";
	public const string SKILL	= "Wizard_Skill";
	public const string DAMAGE	= "Wizard_Damage";
	public const string STUN	= "Wizard_Stun";
	public const string DEATH	= "Wizard_Death";

	Animation anim;

	void Start () {
		anim = GetComponent<Animation>();
	}

	public void IdleAni (){
		anim.CrossFade (IDLE);
	}

	public void RunAni (){
		anim.CrossFade (RUN);
	}

	public void AttackAni (){
		anim.CrossFade (ATTACK);
	}

	public void SkillAni (){
		anim.CrossFade (SKILL);
	}

	public void DamageAni (){
		anim.CrossFade (DAMAGE);
	}

	public void StunAni (){
		anim.CrossFade (STUN);
	}

	public void DeathAni (){
		anim.CrossFade (DEATH);
	}
		
}


















