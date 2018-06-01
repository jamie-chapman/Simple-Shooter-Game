using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed = 7.5f; //Player travel speed
	float camRayLength = 100f; //Raycast length for mouse tracking
	int floorMask;
	Vector3 movement;
	Rigidbody playerRigidBody; 

	void Awake ()
	{
		playerRigidBody = GetComponent<Rigidbody> (); //Get rigidbody game object
	}

	void FixedUpdate()
	{
		//Get inputs from keyboard
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		//Input movement values into move function
		Move (h, v);
		Turning ();

	}
	/*
	 * Set player rigidbody direction using h, v values
	 * Move in with vector(h, 0,v) with speed values
	 */
	void Move(float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidBody.MoveRotation (newRotation);
		}
	}
}