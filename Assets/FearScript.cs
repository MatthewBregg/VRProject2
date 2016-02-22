using UnityEngine;
using System.Collections;

public class FearScript : MonoBehaviour {
	public GameObject player;
	private HeartBeat_ControlScript heartrate;
	public float closeDistance = 10;
	public float mediumDistance = 20;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		heartrate = player.GetComponentInChildren<HeartBeat_ControlScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = transform.position - player.transform.position;
		float sqrLen = offset.sqrMagnitude;
		if (sqrLen < closeDistance * closeDistance) {
			heartrate.heartRate = HeartBeat_ControlScript.HeartRate.Fast;
		} else if (sqrLen < mediumDistance * mediumDistance) {
			heartrate.heartRate = HeartBeat_ControlScript.HeartRate.Mid;
		} else {
			heartrate.heartRate = HeartBeat_ControlScript.HeartRate.Slow;
		}
	}
}
