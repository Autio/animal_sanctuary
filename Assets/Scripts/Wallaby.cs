using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallaby : MonoBehaviour {

    GameObject gm;
    enum states { idle, approaching, departing, roaming, findingFood, eating}
    states currentState;
    private Transform desiredFood;
    private float threshold = 10.0f; // how close to food before food finding ends
    
    // Use this for initialization
	void Start () {
        currentState = states.findingFood;
        gm = GameObject.Find("GameManager");
        Debug.Log("Wallaby born");
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.O))
        {
            FindFood();
        }

        if (currentState == states.findingFood)
        {
            FindFood();
        }

	}

    public void FindFood()
    {
        currentState = states.findingFood;
        // pick random seed if available
        if(desiredFood == null)
        {
            try
            {
                desiredFood = gm.GetComponent<GameManager>().seeds[Random.Range(0, gm.GetComponent<GameManager>().seeds.Count)].transform;
            } catch
            {
                Debug.Log("No seeds found for wallaby");
            }
        }
        else
        {
            // move towards seed
            Debug.Log("Helloe");
            float distance = (transform.position - desiredFood.position).magnitude;
            Debug.Log(distance.ToString());
            transform.Translate((transform.position - desiredFood.position) * Time.deltaTime);
            // if close to food start eating
            if((transform.position - desiredFood.position).magnitude < threshold)
            {
                StartEating();
            }
        }
    }

    public void StartEating()
    {
        // 
        currentState = states.eating;
    }


}
