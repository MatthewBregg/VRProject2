using UnityEngine;
using System.Collections;

public class AttackerAgentScript : MonoBehaviour {
	bool attackStarted = false;
	bool attackTargetReached = false;
	bool retreatTargetReached = false;
	public Transform attackTarget;
	public Transform retreatTarget;
	NavMeshAgent agent;
	Animator anim;

	public GameObject torch;
	public GameObject torchMaster;
	public float firingAngle = 45.0f;
	public float gravity = 9.8f;

	void Start () 
	{
		agent = GetComponent<NavMeshAgent> ();
		Component[] animatorComponents = GetComponentsInChildren<Animator> ();
		anim = animatorComponents [0] as Animator; // there only exists one animator component
		BeginAttack();
	}

	public void BeginAttack ()
	{
		attackStarted = true;
		gameObject.SetActive (true);
		agent.SetDestination (attackTarget.position);
		anim.SetFloat ("Walk", 1);
		anim.SetFloat ("Run", 1);
	}
	
	void Update () 
	{
		if (!attackStarted)
			return;
		
		if (!attackTargetReached && IsDestinationCloseEnough (40.0f)) {
			torch.transform.SetParent (torchMaster.transform);
			StartCoroutine(SimulateProjectile());
			attackTargetReached = true;
			agent.SetDestination (retreatTarget.position);
		} else if (!retreatTargetReached && IsDestinationCloseEnough (0f)) {
			retreatTargetReached = true;
			gameObject.SetActive (false);
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

	bool IsDestinationCloseEnough (float distance)
	{
		if (!agent.pathPending) {
			if ((agent.remainingDistance - distance) <= agent.stoppingDistance) {
				return true;
			}
		}

		return false;
	}
}
