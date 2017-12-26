using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFeed : MonoBehaviour {
    public int seeds = 20;
    public float force = 1.0f;
    public Transform seedObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < seeds; i++)
            {
                Vector3 offset = new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
                Transform newSeed = Instantiate(seedObject, transform.position + offset, Quaternion.identity);
                newSeed.parent = this.transform;
                newSeed.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f); 
            }

        }
	}
}
