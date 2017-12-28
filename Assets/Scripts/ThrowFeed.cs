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
            Throw();
        }
	}

    public void Throw()
    {
        // Get velocity of the player to add that to the throw 
        Debug.Log("Player velocity " + transform.GetComponent<CharacterController>().velocity);

        for (int i = 0; i < seeds; i++)
        {
            Vector3 offset = transform.forward;// Random.Range(0.1f, 0.4f),0);
            offset = offset + new Vector3(Random.Range(0.7f, 1.2f), Random.Range(-0.2f, 0.4f), Random.Range(-0.1f, 0.1f));
            Vector3 velocity = transform.GetComponent<CharacterController>().velocity.normalized;
            offset += velocity;
            Transform newSeed = Instantiate(seedObject, transform.position + offset, Quaternion.identity);
            newSeed.parent = seedParent;
            // add to seed list
            gm.GetComponent<GameManager>().seeds.Add(newSeed.gameObject);
           
            Vector3 orientation = transform.localEulerAngles;
            // newSeed.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f);
            newSeed.GetComponent<Rigidbody>().AddForce(GameObject.Find("FirstPersonCharacter").transform.forward * force);
        }

    }
}
