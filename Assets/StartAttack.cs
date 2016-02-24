using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartAttack : MonoBehaviour {
	public GameObject attackerRoot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private bool ran = false;

	public void OnTriggerEnter(Collider collider) {
		//Debug.Log ("Entered!");
		if (collider.gameObject.CompareTag ("Player")) {
			attackerRoot.SetActive (true);
//			foreach (Transform x in attackerRoot.transform) {
//				x.gameObject.SetActive (true);
//
//			}
			AttackerAgentScript[] attackers = attackerRoot.GetComponentsInChildren<AttackerAgentScript> ();
			//Debug.Log ("Found " + attackers.Length + " attackers");
			this.GetComponentInChildren<HaloMarker> ().gameObject.SetActive (false);

			foreach (AttackerAgentScript attacker in attackers) {
				attacker.BeginAttack ();
			}
			gameObject.SetActive (false);
		}

	}
}
