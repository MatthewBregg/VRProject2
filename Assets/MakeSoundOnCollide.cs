using UnityEngine;
using System.Collections;

public class MakeSoundOnCollide : MonoBehaviour {

    public AudioClip crashSound;

    public void OnTriggerEnter(Collider collision) {
        // next line requires an AudioSource component on this gameobject
        GetComponent<AudioSource>().PlayOneShot(crashSound);
    }
    public void OnCollisionEnter(Collision collision) {
        // next line requires an AudioSource component on this gameobject
        GetComponent<AudioSource>().PlayOneShot(crashSound);
    }
}
