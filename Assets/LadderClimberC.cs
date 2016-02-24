using UnityEngine;
using System.Collections;
//Based off http://answers.unity3d.com/questions/624114/a-simple-ladder-in-c-or-js.html
public class LadderClimberC : MonoBehaviour {

    public GameObject playerObject;
    public bool canClimb = false;
    public float speed = 1;

    public void Start() {

    }
    public void OnTriggerEnter(Collider collider) {

        if (collider.gameObject.CompareTag("Player")) {
            canClimb = true;
            collider.gameObject.GetComponent<Rigidbody>().useGravity = false;

        }
    }

    public void OnTriggerExit(Collider collider) {

        if (collider.gameObject.CompareTag("Player")) {
            canClimb = false;
            collider.gameObject.GetComponent<Rigidbody>().useGravity = true;

        }
    }

    public void Update() {

        if (canClimb == true) {



            if (Input.GetKey(KeyCode.Z) || Input.GetAxis("Vertical") > 0) {
                //Debug.Log("Climbing");
                playerObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);

            }
            if (Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0) {

                playerObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);



            }
        }
    }
}
