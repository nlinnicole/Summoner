using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour {

    public GameObject bridge;
    public GameObject ramp;

	// Use this for initialization
	void Start () {
        bridge.SetActive(false);
        ramp.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bridge.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.K))
            ramp.SetActive(true);
	}
}
