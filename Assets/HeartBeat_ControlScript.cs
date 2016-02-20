using UnityEngine;
using System.Collections;

public class HeartBeat_ControlScript : MonoBehaviour {
    public AudioClip slowBeat;
    public AudioClip midBeat;
    public AudioClip fastBeat;
    private AudioSource source;

    public enum HeartRate { Slow, Mid, Fast, None };

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
	// Update is called once per frame
	void Update () {
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
