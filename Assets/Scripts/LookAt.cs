using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform targetObject;
    public bool lockToPlayer = true;
    private Transform playerObject;
    // delayed? 
    // for performance could update this only sometimes?
    // Use this for initialization
    void Start () {
        playerObject = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(targetObject);
        if(lockToPlayer)
        {
            transform.LookAt(playerObject);
        }
	}
}
