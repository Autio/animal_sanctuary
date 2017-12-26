using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedRandomiser : MonoBehaviour {
    public Sprite[] Sprites;
	// Use this for initialization
	void Start () {
        int r = Random.Range(0, Sprites.Length);
        
            this.GetComponent<SpriteRenderer>().sprite = Sprites[r];
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
