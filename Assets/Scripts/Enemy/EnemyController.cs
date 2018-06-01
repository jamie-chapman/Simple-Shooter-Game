using UnityEngine;
using System.Collections;

//Simulates a wandering movement for AI Enemy 
public class EnemyController : MonoBehaviour
{
	public float speed = 2f;
	public float directionChangeInterval = 1f;
	public float maxHeadingChange = 90f;
	public float heading;

	CharacterController controller;
	Vector3 targetRotation;

	/* 
	* Runs once at start of game
	*/
	void Awake()
	{
		controller = GetComponent<CharacterController> ();
		heading = Random.Range (0, 360);
		transform.eulerAngles = new Vector3 (0, heading, 0);

		StartCoroutine(NewHeading());
	}
	/* 
	* Runs every frame
	* Interpolates between old and new heading
	* Moves enemy forward in heading direction
	*/
	void Update()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed); 
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