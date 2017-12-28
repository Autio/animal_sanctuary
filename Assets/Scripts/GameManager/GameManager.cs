using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class GameManager : MonoBehaviour {

    // Need a weather manager 
    // Traffic, road with a few cars
    // Plenty of vegetation 

    public List<GameObject> seeds;
    public GameObject sun;
	// Use this for initialization
	void Start () {
        sun = GameObject.Find("SunLight");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.K))
        {
            Dusk();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            Day();
        }
	}
     
    // dawn, day, dusk, night
    // directional light intensity should be adjusted, maybe also hue
    // should be synched to the sun and moons
    // -> Resting area
    // 

    void Dusk()
    {
        sun.GetComponent<Light>().intensity = 0.1f;
    }

    void Day()
    {
        sun.GetComponent<Light>().intensity = 1.0f;
    }

}
