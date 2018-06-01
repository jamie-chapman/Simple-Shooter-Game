using UnityEngine;
using System.Collections;

public interface ITeamMateState 
{
	void UpdateState ();

	void OnTriggerEnter (Collider other);

	void ToPatrolState();

	void ToAlertState();

	void ToSeekState();

}
