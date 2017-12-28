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
    GameObject sunObject;
	// Use this for initialization
	void Start () {
        sun = GameObject.Find("SunLight");
        sunObject = GameObject.Find("sun2_0");
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

        // lerp -208 to 208 to 0.3 to 1.5 - remap the sun's altitude to the directional light brightness
        if (sunObject.transform.position.y > -20.0f)
        {
            sun.GetComponent<Light>().intensity = Remap(sunObject.transform.position.y, -25.0f, 208.0f, 0.2f, 1.5f);
        } 
        else
        {

        }
	}

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {


            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;


    }

  

    // dawn, day, dusk, night
    // directional light intensity should be adjusted, maybe also hue
    // should be synched to the sun and moons
    // -> Resting area
    // 
    // 208 is the current sun apex
    // -5 is the lowest, so say -
    void Dark()
    {
        sun.GetComponent<Light>().intensity = 0.3f;
    }
    void Dusk()
    {
        //D8CB98FF
        sun.GetComponent<Light>().intensity = 0.8f;
    }

    void Day()
    {
        sun.GetComponent<Light>().intensity = 1.5f;
    }

}
