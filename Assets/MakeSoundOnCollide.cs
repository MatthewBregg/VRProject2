using UnityEngine;
using System.Collections;

public class MakeSoundOnCollide : MonoBehaviour {

    public AudioClip crashSound;
	public float coolDown = 0f;
	private float cooldownCounter = 0f;

	public void playSound() {
		if ( cooldownCounter > coolDown) {
			cooldownCounter = 0;
			GetComponent<AudioSource> ().PlayOneShot (crashSound);
		}
	}
    public void OnTriggerEnter(Collider collision) {
        // next line requires an AudioSource component on this gameobject
		playSound();
    }
    public void OnCollisionEnter(Collision collision) {
        // next line requires an AudioSource component on this gameobject
		playSound();
    }
	public void Update() {
		cooldownCounter += Time.deltaTime;
	}
}
