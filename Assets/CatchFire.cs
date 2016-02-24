using UnityEngine;
using System.Collections;

public class CatchFire : MonoBehaviour {
	public GameObject Fire;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag ("CowboyTorch")) {
			Debug.Log ("making the hut burn");
			Fire.SetActive (true);
		}
	}

}
