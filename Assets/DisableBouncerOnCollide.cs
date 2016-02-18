using UnityEngine;
using System.Collections;

public class DisableBouncerOnCollide : MonoBehaviour {
    public GameObject bouncer;
    public GameObject guide;
    public GameObject lift;
    public bool setTo;
    // Use this for initialization
    void Start () {
	
	}

    void setAllActive(bool active) {
        bouncer.SetActive(active);
        guide.SetActive(active);
        lift.SetActive(active);
    }
    public void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.CompareTag("Player")) {
            setAllActive(setTo);

        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
