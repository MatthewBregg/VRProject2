using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class HeartBeat_ControlScript : MonoBehaviour {
    public AudioClip slowBeat;
    public AudioClip midBeat;
    public AudioClip fastBeat;
	public GameObject player;
    private AudioSource source;
	private List<FearSource> fearSources = new List<FearSource>();

    public enum HeartRate { None = 0, Slow = 1, Mid = 2, Fast = 3 };

    private HeartRate currentlyPlaying = HeartRate.None;

    public HeartRate heartRate = HeartRate.None;
    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}
	void loadAudio(AudioClip clip) {
        source.clip = clip;
        source.Play();
    }
	struct FearSource {
		public float medium;
		public float near;
		public Transform t;
	}

	public void registerFearSource(Transform t, float medium, float near) {
		FearSource source = new FearSource ();
		source.near = near;
		source.medium = medium;
		source.t = t;
		fearSources.Add (source);
	}
	void checkSources() {
		heartRate = HeartRate.None;
		//Logic here
		//Loop through each thingy we are scared of, and take the one that scares us the most, and set our heart rate.
		//If there is nothing in the scene to scare us, then set the heart rate to be off.
		//But, if there is something in the scene that does scare us, anything at all, then heartrate should be slow.
		foreach ( FearSource source in fearSources) {
			if (!source.t.gameObject.activeInHierarchy) {
				continue;
			}
			HeartRate tempHeartRate = HeartRate.None;
			Vector3 offset = source.t.position - player.transform.position;
			float sqrLen = offset.sqrMagnitude;
			if (sqrLen < source.near * source.near) {
				//Debug.Log ("Making Heart Rate Go");
				tempHeartRate = HeartBeat_ControlScript.HeartRate.Fast;
			} else if (sqrLen < source.medium * source.medium) {
				//Debug.Log ("Making Heart Rate Go");
				tempHeartRate = HeartBeat_ControlScript.HeartRate.Mid;
			} else {
				tempHeartRate = HeartRate.Slow;
			}
			int result = (int)(Mathf.Max ((float)tempHeartRate, (float)heartRate));
			heartRate = (HeartRate)result;
		}
	}
	// Update is called once per frame
	void Update () {
		checkSources ();
        if (heartRate != currentlyPlaying) {
            switch(heartRate) {
                case HeartRate.None:
                    source.Stop();
                    break;
                case HeartRate.Slow:
                    loadAudio(slowBeat);
                    break;
                case HeartRate.Mid:
                    loadAudio(midBeat);
                    break;
                case HeartRate.Fast:
                    loadAudio(fastBeat);
                    break;       
            }
            currentlyPlaying = heartRate;
            
        }
	    
	}

    //source = GetComponent<AudioSource>().clip
    //GetComponent<AudioSource>().Play();

}
