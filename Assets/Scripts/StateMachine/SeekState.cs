using UnityEngine;
using System.Collections;

public class SeekState : ITeamMateState 
{
	private readonly StatePatternTeamMate teamMate;

	public SeekState(StatePatternTeamMate statePatternTeamMate)
	{
		teamMate = statePatternTeamMate;
	}
	public void UpdateState ()
	{
		Look ();
		Seek ();
	}
	public void OnTriggerEnter(Collider other)
	{

	}

	public void ToPatrolState()
	{

	}

	public void ToAlertState()
	{
		teamMate.currentState = teamMate.alertState;
	}

	public void ToSeekState()
	{
		
	}

	private void Look()
	{
		RaycastHit hit;
		Vector3 teamMateToTarget = ((teamMate.seekTarget.position + teamMate.offset) - teamMate.eyes.transform.position);
		if (Physics.Raycast (teamMate.eyes.transform.position, teamMateToTarget, out hit, teamMate.sightRange) && hit.collider.CompareTag ("Player")) {
			teamMate.seekTarget = hit.transform;
		}
		else 
		{
			ToAlertState ();
		}
	}

	private void Seek()
	{
		teamMate.meshRendererFlag.material.color = Color.red;
		teamMate.nav.destination = teamMate.seekTarget.position;
		teamMate.nav.Resume();
	}
}
