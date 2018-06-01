using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 3f;
	public Transform[] spawnPoints;

	void Awake () 
	{
		InvokeRepeating ("Spawn", 20f, spawnTime);
	}

	void Spawn () 
	{
		if (playerHealth.health != 0f) 
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			print ("Spawn!");

		}
	}
}
