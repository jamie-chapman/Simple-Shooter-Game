using UnityEngine;
using System.Collections;

public class SeekHealth : MonoBehaviour 
{
	public int health;
	public int score;

	void Update()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter(Collision target)
	{
		//If enemy is hit by gameObject projectile, take damage
		if (target.transform.gameObject.name == "projectile(Clone)") 
		{
			health -= 5;
			Score.score += score;
		} 
		else if (target.transform.gameObject.name == "Player") 
		{
			health = 0;
		}
	}
}