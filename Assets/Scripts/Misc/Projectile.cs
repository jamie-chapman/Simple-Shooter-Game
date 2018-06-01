using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	void Update()
	{
		Destroy (this, 2.0f);
	}

	void OnCollisionEnter()
	{
		Destroy(gameObject);
	}
}
