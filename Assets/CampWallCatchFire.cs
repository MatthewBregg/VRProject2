using UnityEngine;
using System.Collections;

public class CampWallCatchFire : MonoBehaviour {
	public GameObject FireToInstantiate;
	public float delay = 10;
	private bool onFire = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag ("CowboyTorch")) {
			//Debug.Log ("Wall lighting on fire");
			initiateFire ();
		}
		
	}
	public void initiateFire() {
		if (onFire) {
			return;
		}
		onFire = true; //Don't make multiple fires, and don't keep spreading fire!
		GameObject childfire = Object.Instantiate (FireToInstantiate);
		childfire.transform.parent = transform;	
		childfire.transform.position = new Vector3 (0, 0, 0);
		childfire.transform.localPosition = new Vector3 (0, 0, 0);
		childfire.transform.rotation = transform.rotation;
		childfire.SetActive (true);

		StartCoroutine(LightOnFireAfterTime (delay));


	}
	IEnumerator LightOnFireAfterTime(float time)
	{
		yield return new WaitForSeconds(time);
		int index = transform.GetSiblingIndex ();
		GameObject nextBrotherNode = transform.parent.GetChild (index + 1).gameObject;
		nextBrotherNode.GetComponent<CampWallCatchFire> ().initiateFire ();
		if (index > 0) {
			GameObject previousBrotherNode = transform.parent.GetChild (index - 1).gameObject;
			previousBrotherNode.GetComponent<CampWallCatchFire> ().initiateFire ();
		}

	}


}
