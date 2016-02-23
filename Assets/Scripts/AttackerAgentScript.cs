using UnityEngine;
using System.Collections;

public class AttackerAgentScript : MonoBehaviour {
	public Transform attackTarget;
	public Transform retreatTarget;
	bool attackTargetReached = false;
	bool retreatTargetReached = false;
	NavMeshAgent agent;
	Animator anim;

	public GameObject torch;
	public GameObject torchMaster;
	public float firingAngle = 45.0f;
	public float gravity = 9.8f;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (attackTarget.position);

		Component[] animatorComponents = GetComponentsInChildren<Animator> ();
		anim = animatorComponents [0] as Animator; // there only exists one animator component
		anim.SetFloat ("Walk", 1);
		anim.SetFloat ("Run", 1);
	}
	
	void Update () 
	{
		if (!attackTargetReached && IsDetinationReached ()) {
			torch.transform.SetParent (torchMaster.transform);
			StartCoroutine(SimulateProjectile());
			attackTargetReached = true;
			agent.SetDestination (retreatTarget.position);
		} else if (!retreatTargetReached && IsDetinationReached ()) {
			retreatTargetReached = true;
			anim.SetFloat ("Walk", 0);
			anim.SetFloat ("Run", 0);
		}
	}

	IEnumerator SimulateProjectile()
	{
		// Short delay added before Projectile is thrown
		yield return new WaitForSeconds(1.5f);

		// Move projectile to the position of throwing object + add some offset if needed.
		torch.transform.position = transform.position + new Vector3(0, 0.0f, 0);

		// Calculate distance to target
		float target_Distance = Vector3.Distance(torch.transform.position, attackTarget.position);

		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

		// Extract the X  Y componenent of the velocity
		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

		// Calculate flight time.
		float flightDuration = target_Distance / Vx;

		// Rotate projectile to face the target.
		torch.transform.rotation = Quaternion.LookRotation(attackTarget.position - torch.transform.position);

		float elapse_time = 0;

		while (elapse_time < flightDuration)
		{
			torch.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

			elapse_time += Time.deltaTime;

			yield return null;
		}
	}  

	bool IsDetinationReached ()
	{
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					return true;
				}
			}
		}

		return false;
	}
}
