using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
	public Transform projectileSpawnPoint;
	public GameObject projectileObject;

	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			var projectile = (GameObject)Instantiate (
				projectileObject,
				projectileSpawnPoint.position,
				projectileSpawnPoint.rotation);
			
			projectile.GetComponent<Rigidbody> ().velocity = projectile.transform.forward * 40f;
		}
	}
}