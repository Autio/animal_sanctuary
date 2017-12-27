using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ThrowFeed : MonoBehaviour {
    public int seeds = 20;
    public float force = 1.0f;
    public Transform seedObject;
    private Transform seedParent;
    private GameObject gm;
	// Use this for initialization
	void Start () {
        seedParent = GameObject.Find("Seeds").transform;
        gm = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < seeds; i++)
            {
                Vector3 offset = new Vector3(Random.Range(0.2f, 0.6f), Random.Range(0.1f, 0.4f), Random.Range(0.5f, 1.5f));
                Transform newSeed = Instantiate(seedObject, transform.position + offset, Quaternion.identity);
                newSeed.parent = seedParent;
                // add to seed list
                gm.GetComponent<GameManager>().seeds.Add(newSeed.gameObject);

                newSeed.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f);
                newSeed.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
            }

        }
	}
}
