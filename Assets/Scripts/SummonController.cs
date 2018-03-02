using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour {
    public GameObject SpawnPoints;
    public GameObject bridge;
    public GameObject portalEnter;
    public GameObject portalExit;
    public GameObject ramp;

    public static int index = 0;

    private List<GameObject> spawn = new List<GameObject>();
    private int portalOffset = 5;

    void Start()
    {
        foreach (Transform child in SpawnPoints.transform)
        {
            spawn.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("bridge");
            bridge.transform.position = spawn[index].transform.position;
            bridge.SetActive(true);
            ++index;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if(spawn[index].tag == "isRaised")
            {
                Debug.Log("ramp");
                ramp.transform.position = spawn[index].transform.position;
                ramp.SetActive(true);
                ++index;
            } else
            {
                Debug.Log("r");
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Vector3 portalEnterLoc = spawn[index].transform.position;
            portalEnterLoc.x -= portalOffset;

            portalEnter.transform.position = portalEnterLoc;
            portalEnter.SetActive(true);

            Vector3 portalExitLoc = spawn[index].transform.position;
            portalExitLoc.x = +portalOffset;

            portalExit.transform.position = portalExitLoc;
            portalExit.SetActive(true);

            GameObject player = GameObject.Find("Player");
            CharController charControl = player.GetComponent<CharController>();
            charControl.index = index;

            ++index;
        }
    }
}
