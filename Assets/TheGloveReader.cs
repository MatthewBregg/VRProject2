using UnityEngine;
using System.Collections;

public class TheGloveReader : MonoBehaviour {
    char[] whitespace = new char[] { ' ', '\t' };
    Transform t;
    // Use this for initialization
    void Start () {
	    t = GetComponent<Transform>();
    }
	
	// Update is called once per frame
    private float nextActionTime = 0.0f;
    public float period = 0.0f;


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            // execute block of code here
            string[] lines = System.IO.File.ReadAllLines(@".\Glove Stuff\ConsoleApplication2\data.dat");
            // Debug.Log("Position: " + lines[0]);
            // Debug.Log("Orientation: " + lines[1]);
            string[] xyz = lines[0].Split(null);
            string[] pitchyawroll = lines[1].Split(null);
            //Debug.Log("Test: " + xyz[0]);
           // t.eulerAngles = new Vector3(-float.Parse(pitchyawroll[2]),
            //    -float.Parse(pitchyawroll[0]), -float.Parse(pitchyawroll[1]));
            int reducer = 10;
            t.localPosition = 
              new Vector3(1+float.Parse(xyz[0])/reducer, float.Parse(xyz[1])/reducer, -float.Parse(xyz[0])/reducer);
        }
    }

       

}
