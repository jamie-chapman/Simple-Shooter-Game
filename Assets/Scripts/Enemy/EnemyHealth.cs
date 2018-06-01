using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int health;
	public int score;

	void Update()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
			Score.score += score;
		}
	}
	void OnCollisionEnter(Collision target)
	{
		//If enemy is hit by gameObject projectile, take damage
		if (target.transform.gameObject.name == "projectile(Clone)")
		{
			health -= 5;
		}
	}
}