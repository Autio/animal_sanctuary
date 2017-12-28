using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallaby : MonoBehaviour {

    GameObject gm;
    public float hopForce = 500.0f;
    enum states { idle, approaching, departing, roaming, findingFood, eating}
    states currentState;
    private Transform desiredFood;
    private float threshold = 2.0f; // how close to food before food finding ends
    private float hopTimer;
    // Use this for initialization
	void Start () {
        currentState = states.findingFood;
        gm = GameObject.Find("GameManager");
        Debug.Log("Wallaby born");
        hopTimer = Random.Range(0.6f, 1.2f);
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
            hopTimer -= Time.deltaTime;
            if(hopTimer<0)
            {
                hopTimer = Random.Range(0.6f, 1.2f);

                Debug.Log("Hopping");
                float distance  = (transform.position - desiredFood.position).magnitude;
                Debug.Log(distance.ToString());
                Vector3 dir =  ( desiredFood.position - transform.position).normalized;

                GetComponent<Rigidbody>().AddForce(dir * hopForce);

            }
            //transform.Translate((transform.position - desiredFood.position) * Time.deltaTime);
            // if close to food start eating
            if ((transform.position - desiredFood.position).magnitude < threshold)
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
