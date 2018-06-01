using UnityEngine;
using System.Collections;

//Combines seeking steering behaviour with wandering behavoiour
public class SeekEnemyController : MonoBehaviour
{
	public float speed = 1.5f;
	float movement;
	//Wander variables
	public float directionChangeInterval = 0.1f;
	public float maxHeadingChange = 120f;
	public float heading;
	CharacterController controller;
	Vector3 targetRotation;

	//Seek variables
	public NavMeshAgent nav;
	public Transform player;

	/* 
	* Runs once at start of game
	*/
	void Awake()
	{
		//Get character controller and set up a random initial direction/heading
		controller = GetComponent<CharacterController> ();
		heading = Random.Range (0, 360);
		transform.eulerAngles = new Vector3 (0, heading, 0);

		StartCoroutine (NewHeading ());
		//Get nav mesh component for seek
		nav = GetComponent <NavMeshAgent> ();
	}
	/* 
	* Runs every frame
	* Interpolates between old and new heading
	* Moves enemy forward in heading direction
	*/
	void Update()
	{
		movement = Random.Range (0, 9);
		if (movement <= 2) {
			//print ("Seek :> " + movement);
			Seek ();
		} else if (movement > 2) {
			//print ("Wander :> " + movement);
			Wander ();

		}
	}

	void Wander()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed); 
	}
	void Seek()
	{
		nav.SetDestination (player.position);
	}

	/*
	* Run newHeading every directionChangeInterval amount of seconds 
	*/
	IEnumerator NewHeading()
	{
		while(true) {
			NewHeadingRoutine ();
			yield return new WaitForSeconds (directionChangeInterval);
		}
	}
	/*
	* Generate random value from 0 - 360, set value to new y vector
	*/
	void NewHeadingRoutine()
	{
		heading = Random.Range (0, 360);
		targetRotation = new Vector3(0, heading, 0);
	}
}
