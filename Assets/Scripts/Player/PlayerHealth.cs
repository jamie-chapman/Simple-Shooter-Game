using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health;
	public Slider healthSlider;
	
	//Set initial health to 100
	void Start()
	{
		health = 100;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0) 
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision target)
	{
		//If enemy is hit by gameObject projectile, take damage
		if (target.transform.gameObject.name == "projectile(Clone)" || target.transform.gameObject.name == "SeekEnemy") 
		{
			health -= 25;
			healthSlider.value = 100 - health;
		}  
	}
}
