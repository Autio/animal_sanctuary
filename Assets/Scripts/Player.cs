using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    GameObject heldObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T))
        {
            heldObject = GameObject.Find("Hold");
            Throw(700.0f);
        }
	}

    public void SetHeldObject(GameObject g)
    {
        heldObject = g;
    }
    public GameObject GetHeldObject()
    {
        return heldObject;
    }

    public void Pickup()
    {
        // try and pick up the object in front of you

    }
    public void Throw(float force)
    {
        Vector3 offset = transform.forward;// Random.Range(0.1f, 0.4f),0);
        offset = offset + new Vector3(Random.Range(0.7f, 1.2f), Random.Range(-0.2f, 0.4f), Random.Range(-0.1f, 0.1f));
        Vector3 velocity = transform.GetComponent<CharacterController>().velocity.normalized;
        offset += velocity;
        Vector3 orientation = transform.localEulerAngles;
        // newSeed.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, 5.0f);
        heldObject.transform.parent = null;
        heldObject.GetComponent<Rigidbody>().AddForce((velocity + GameObject.Find("FirstPersonCharacter").transform.forward) * force);
        heldObject.GetComponent<Rigidbody>().AddForce(GameObject.Find("FirstPersonCharacter").transform.up * force/2);
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        
        // object no longer held
        heldObject = null;
    }
}
