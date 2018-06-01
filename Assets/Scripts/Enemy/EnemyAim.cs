using UnityEngine;
using System.Collections;

public class EnemyAim : MonoBehaviour 
{
	public Transform target; //Position of player

	/*
	 * aimInterval can be tweaked to add a level of artificial stupidity to the enemy
	 * the shorter the interval, the more likely the enemy is to achive a shot on targer
	 */
	public float aimInterval = 0.15f; //The time between aiming at the player

	void Awake()
	{
		InvokeRepeating ("Aim", 1f, aimInterval); 
	}

	void Aim () 
	{
		transform.LookAt (target);
	}
}