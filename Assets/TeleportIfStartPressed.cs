using UnityEngine;
using System.Collections;

public class TeleportIfStartPressed : MonoBehaviour {
	private bool teleported = false;
	GameObject player;


	private CharacterController controller;

	void Start(){
		controller = GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Submit") && !teleported) {
			Debug.Log ("Teleport!");
			teleported = true;
			player.transform.position = new Vector3(231.5f,4.69f,141.28f);

		}
	}
}
