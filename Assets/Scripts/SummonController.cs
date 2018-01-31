using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour {

    public GameObject ramp;

    public GameObject[] bridges;
    public GameObject[] portalEnter;
    public GameObject[] portalExit;

    public static int index = 0;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.J))
        {
            bridges[index].SetActive(true);
            Debug.Log("bridge");
            Debug.Log(index);
            index++;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            ramp.SetActive(true);
            Debug.Log("ramp");
            Debug.Log(index);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            portalEnter[index].SetActive(true);
            portalExit[index].SetActive(true);

            Debug.Log("portal");
            Debug.Log(index);

            GameObject player = GameObject.Find("Player");
            CharController charControl = player.GetComponent<CharController>();
            charControl.index = index;

            index++;
        }
    }
}
