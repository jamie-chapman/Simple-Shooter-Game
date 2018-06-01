using UnityEngine;
using System.Collections;

public class AlertState : ITeamMateState 
{
	private readonly StatePatternTeamMate teamMate;
	private float searchTimer;

	public AlertState(StatePatternTeamMate statePatternTeamMate)
	{
		teamMate = statePatternTeamMate;
	}

	public void UpdateState ()
	{
		Look ();
		Search ();
	}

	public void OnTriggerEnter (Collider other)
	{

	}

	public void ToPatrolState()
	{
		teamMate.currentState = teamMate.patrolState;
		searchTimer = 0f;
	}

	public void ToAlertState()
	{
		Debug.Log ("Can't switch to same state");
	}

	public void ToSeekState()
	{
		teamMate.currentState = teamMate.seekState;
		searchTimer = 0f;
	}

	private void Look()
	{
		RaycastHit hit;
		if (Physics.Raycast (teamMate.eyes.transform.position, teamMate.eyes.transform.forward, out hit, teamMate.sightRange) && hit.collider.CompareTag ("Player")){
			
			teamMate.seekTarget = hit.transform;
			ToSeekState ();
		}
	}

	private void Search()
	{
		teamMate.meshRendererFlag.material.color = Color.yellow;
		teamMate.nav.Stop ();
		teamMate.transform.Rotate (0, teamMate.searchingTurnSpeed * Time.deltaTime, 0);
		searchTimer += Time.deltaTime;

		if(searchTimer >= teamMate.searchingDuration)
		{
			ToPatrolState();
		}
	}
}
