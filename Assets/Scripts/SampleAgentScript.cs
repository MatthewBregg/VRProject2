using UnityEngine;
using System.Collections;

public class SampleAgentScript : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () 
	{
		agent.SetDestination (target.position);

		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					Debug.Log ("reached destination");
				}
			}
		}

	}
}
