using UnityEngine;
using System.Collections;

public class FearScript : MonoBehaviour {
	public GameObject player;
	public float closeDistance = 10;
	public float mediumDistance = 20;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
		player.GetComponentInChildren<HeartBeat_ControlScript> ().registerFearSource(GetComponent<Transform>(),mediumDistance,closeDistance);
	}
	

}
