using UnityEngine;
using System.Collections;

public class PatrolState : ITeamMateState 
{
	private readonly StatePatternTeamMate teamMate;
	private int nextWayPoint;

	public PatrolState(StatePatternTeamMate statePatternTeamMate)
	{
		teamMate = statePatternTeamMate;
	}

	public void UpdateState ()
	{
		Look ();
		Patrol ();
	}

	public void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
			ToAlertState ();
	}

	public void ToPatrolState()
	{
		Debug.Log ("Can't transition to same state");
	}

	public void ToAlertState()
	{
		teamMate.currentState = teamMate.alertState;
	}

	public void ToSeekState()
	{
		teamMate.currentState = teamMate.seekState;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (teamMate.eyes.transform.position, teamMate.eyes.transform.forward, out hit, teamMate.sightRange) && hit.collider.CompareTag ("Player")) {
			teamMate.seekTarget = hit.transform;
			ToSeekState ();
		}
	}

	void Patrol()
	{
		teamMate.meshRendererFlag.material.color = Color.green;
		teamMate.nav.destination = teamMate.waypoints [nextWayPoint].position;
		teamMate.nav.Resume ();

		if(teamMate.nav.remainingDistance <= teamMate.nav.stoppingDistance && !teamMate.nav.pathPending)
		{
			nextWayPoint = (nextWayPoint + 1) % teamMate.waypoints.Length;
		}
	}
}
