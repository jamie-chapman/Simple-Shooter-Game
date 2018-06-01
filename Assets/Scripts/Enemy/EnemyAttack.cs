using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public Transform projectileSpawnPoint;
	public GameObject projectileObject;

	void Awake()
	{
		InvokeRepeating ("Shoot", 5.0f, 2.0f); //Pause for initial seconds then call shoot method every seconds 
	}

	//Shoots projectile from direction characters facing
	void Shoot()
	{
		var projectile = (GameObject)Instantiate (
			                 projectileObject,
			                 projectileSpawnPoint.position,
			                 projectileSpawnPoint.rotation);

		projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * 20f;
	}
}

