using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour {
    public GameObject SpawnPoints;

    public GameObject bridge;
    public GameObject bigBridge;
    public GameObject portalEnter;
    public GameObject portalExit;
    public GameObject stairs;

    public static int index = 0;

    private List<GameObject> spawn = new List<GameObject>();

    void Start()
    {
        //Add spawn point positions to spawn list
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
            if(spawn[index].tag == "BridgeOnly")
            {
                Debug.Log("bridge only");
                Vector3 bridgeLoc = spawn[index].transform.position;
                bridgeLoc.y += 6.6f; //add position offset
                bridge.transform.position = bridgeLoc;
                bridge.SetActive(true);
                ++index;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (spawn[index].tag == "BigB_Portal")
            {
                Debug.Log("big bridge");
                Vector3 bigBridgeLoc = spawn[index].transform.position;
                bigBridgeLoc.y += 5;
                bigBridge.SetActive(true);
                ++index;
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (spawn[index].tag == "Stairs_Portal")
            {
                Debug.Log("stairs");
                stairs.transform.position = spawn[index].transform.position;
                stairs.SetActive(true);
                ++index;
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // Stairs and Raised Portal
            if (spawn[index].tag == "Stairs_Portal") 
            {
                Debug.Log("raised portal");

                //portal enter
                Vector3 portalEnterLoc = spawn[index].transform.position;
                portalEnterLoc.x -= 8f;
                portalEnterLoc.y += 1.0f;
                portalEnter.transform.position = portalEnterLoc;
                portalEnter.SetActive(true);

                //portal exit
                Vector3 portalExitLoc = spawn[index].transform.position;
                portalExitLoc.x += 8f;
                portalExitLoc.y += 7f;
                portalExit.transform.position = portalExitLoc;                
                portalExit.SetActive(true);

                GameObject player = GameObject.Find("Player");
                CharController charControl = player.GetComponent<CharController>();
                charControl.index = index;

                ++index;
            }

        }
    }
}
