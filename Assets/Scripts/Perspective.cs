using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour {
    public GameObject front;
    public GameObject back;
    public bool frontCheck = true;
    // Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (frontCheck)
            {
                front.SetActive(true);
                back.SetActive(false);
            } else
            {
                front.SetActive(false);
                back.SetActive(true);
            }
        }
    }

}
