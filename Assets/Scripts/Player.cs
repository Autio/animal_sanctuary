using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    class heldObjectData : MonoBehaviour
    {
        public bool lookAt;
        public bool lookAtPlayer;
        
    }

    GameObject heldObject;
    GameObject heldObjectPlace;
    heldObjectData hod = new heldObjectData();
    float heldObjectSize;
	// Use this for initialization
	void Start () {
        heldObjectPlace = GameObject.Find("Hold");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            if (heldObject == null)
            {

                TryGrabObject(GetMouseHoverObject(5));
            }
            else
            {
                TryDropObject();
            }
        }

        if(heldObject != null)
        {
            Vector3 newPosition = heldObjectPlace.transform.position;
            heldObject.transform.position = newPosition;
        }




		if(Input.GetKeyDown(KeyCode.T))
        {
         //   heldObject = GameObject.Find("Hold");
            Throw(700.0f);
        }

       // Debug.Log(GetMouseHoverObject(5.0f));
	}

    public void SetHeldObject(GameObject g)
    {
        heldObject = g;
    }
    public GameObject GetHeldObject()
    {
        return heldObject;
    }

    GameObject GetMouseHoverObject(float range)
    {
        int layerMask = 1 << 2;
        layerMask = ~layerMask;
        Vector3 position = GameObject.Find("FirstPersonCharacter").transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit, layerMask))
            Debug.Log("Picking up object " + raycastHit.collider.gameObject.name);
            return raycastHit.collider.gameObject;
        return null;
        // try and pick up the object in front of you
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null)
            return;

        heldObject = grabObject;

        try
        {
            heldObject.transform.GetComponent<LookAt>().enabled = true;
            heldObject.transform.GetComponent<LookAt>().lockToPlayer = true;
        }
        catch
        {
            Debug.Log("Grabbed object did not have a lookat script");
        }
    }

    void TryDropObject()
    {
        if (heldObject == null)
            return;
        ObjectRevert();
        heldObject = null;

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

        // Object reverts to its original properties: 
        ObjectRevert();

        // object no longer held
        heldObject = null;


    }

    void StoreObjectData()
    {
        try
        {
            if (heldObject.GetComponent<LookAt>().enabled)
            {
                hod.lookAt = true;
            }
            else
            {
                hod.lookAt = false;
            }
        }
        catch
        {
            Debug.Log("Issue in storing held object data");
        }
        try
        {
            if (heldObject.GetComponent<LookAt>().enabled && heldObject.GetComponent<LookAt>().lockToPlayer)
            {
                hod.lookAtPlayer = true;
            }
            else
            {
                hod.lookAtPlayer = false;
            }
        }
        catch
        {
            Debug.Log("Issue in storing held object data");
        }
    }

    void ObjectRevert()
    {
        heldObject.GetComponent<Rigidbody>().useGravity = true;

        if (hod.lookAt)
        {
            heldObject.GetComponent<LookAt>().enabled = true;
        }
        if(hod.lookAtPlayer)
        {
            heldObject.GetComponent<LookAt>().lockToPlayer = true;
        } else
        {
            heldObject.GetComponent<LookAt>().lockToPlayer = false;
        }

        // orient normally
        if(heldObject.transform.position.y < -5f)
        {
            heldObject.transform.position = new Vector3(heldObject.transform.position.x, -4, heldObject.transform.position.z);
        }
        heldObject.transform.rotation = new Quaternion(0,0,0,0);
    }
}
