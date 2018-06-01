using UnityEngine;
using System.Collections;

public class FleeEnemyController : MonoBehaviour 
{
	public float speed = 1f;
	float movement;

	//Flee variables
	public Transform[] fleePoints;
	public NavMeshAgent nav;
	public EnemyHealth enemyHealth;
	//Seek variables
	public Transform player;

	void Awake()
	{
		//Get nav mesh component for flee and seek
		nav = GetComponent <NavMeshAgent> ();
		enemyHealth = GetComponent<EnemyHealth> ();

		int fleePointIndex = Random.Range (0, fleePoints.Length);
	}
	/* 
	* Runs every frame
	* Interpolates between old and new heading
	* Moves enemy forward in heading direction
	*/
	void Update()
	{
		if (enemyHealth.health == 20)
		{
			//print ("Seek" + enemyHealth.health);
			Seek ();
		} 
		else if(enemyHealth.health < 20) 
		{
			//print ("Flee" + enemyHealth.health);
			speed = speed * 2;	
			Flee ();
		}
	}
	void Seek()
	{
		nav.SetDestination (player.position);
	}
	void Flee()
	{
		int fleePointIndex = Random.Range (0, fleePoints.Length);

		nav.SetDestination (fleePoints [fleePointIndex].position);
	}
}