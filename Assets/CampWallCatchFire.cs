using UnityEngine;
using System.Collections;

public class CampWallCatchFire : MonoBehaviour {
	public GameObject FireToInstantiate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnCollidionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("CowboyTorch")) {
			Object.Instantiate (FireToInstantiate);
		}
	}
}
