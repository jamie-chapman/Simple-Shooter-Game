using UnityEngine;
using System.Collections;

public class StatePatternTeamMate : MonoBehaviour 
{
	public float searchingTurnSpeed = 120f;
	public float searchingDuration = 4f;
	public float sightRange = 20f;
	public Transform[] waypoints;
	public Transform eyes;
	public Vector3 offset = new Vector3 (0, 0, 0);
	public MeshRenderer meshRendererFlag;

	[HideInInspector] public Transform seekTarget;
	[HideInInspector] public ITeamMateState currentState;
	[HideInInspector] public SeekState seekState;
	[HideInInspector] public AlertState alertState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public NavMeshAgent nav;

	private void Awake()
	{
		seekState = new SeekState (this);
		alertState = new AlertState (this);
		patrolState = new PatrolState (this);

		nav = GetComponent<NavMeshAgent> ();
	}

	void Start()
	{
		currentState = patrolState;
	}

	// Update is called once per frame
	void Update () 
	{
		currentState.UpdateState ();
	}

	private void OnTriggerEnter(Collider other)
	{
		currentState.OnTriggerEnter (other);
	}
}
