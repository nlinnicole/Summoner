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
    private GameObject closestSpawn;
    private Vector3 position;

    void Start()
    {
        foreach (Transform child in SpawnPoints.transform)
            spawn.Add(child.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;
        summon();
    }

    void summon()
    {
        if (Input.anyKey)
        {
            check();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (closestSpawn.tag == "BridgeOnly")
            {
                GameObject clone;
                Debug.Log("bridge only");
                Vector3 bridgeLoc = closestSpawn.transform.position;
                clone = Instantiate(bridge, bridgeLoc, Quaternion.Euler(-90, 0, 0));
                clone.SetActive(true);
                ++index;
            } else
            {
                //Invalid summon
                Debug.Log("Too far away");
            }

        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (closestSpawn.tag == "BigB_Portal")
            {
                GameObject clone;
                Debug.Log("big bridge");
                Vector3 bigBridgeLoc = closestSpawn.transform.position;
                bigBridgeLoc.y += 4;
                clone = Instantiate(bigBridge, bigBridgeLoc, Quaternion.Euler(-90, 180, 0));
                clone.SetActive(true);
                ++index;
            }
            else
            {
                //Invalid summon
                Debug.Log("Too far away");
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (closestSpawn.tag == "Stairs_Portal")
            {
                GameObject clone;
                Debug.Log("stairs");
                Vector3 stairsLoc = closestSpawn.transform.position;
                clone = Instantiate(stairs, stairsLoc, Quaternion.Euler(-90, 180, 0));
                clone.SetActive(true);
                ++index;
            }
            else
            {
                //Invalid summon
                Debug.Log("Too far away");
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // Stairs and Raised Portal
            if (closestSpawn.tag == "Stairs_Portal")
            {
                GameObject clone1, clone2;
                Debug.Log("raised portal");

                //portal enter
                Vector3 portalEnterLoc = closestSpawn.transform.position;
                portalEnterLoc.x -= 8f;
                portalEnterLoc.y += 1.0f;
                clone1 = Instantiate(portalEnter, portalEnterLoc, Quaternion.Euler(-90, 90, 0));
                clone1.SetActive(true);

                //portal exit
                Vector3 portalExitLoc = closestSpawn.transform.position;
                portalExitLoc.x += 8f;
                portalExitLoc.y += 7f;
                clone2 = Instantiate(portalExit, portalExitLoc, Quaternion.Euler(-90, 90, 0));
                clone2.SetActive(true);

                GameObject player = GameObject.Find("Player");
                CharController charControl = player.GetComponent<CharController>();
                charControl.index = index;

                ++index;
            }
            else
            {
                //Invalid summon
                Debug.Log("Too far away");
            }

        }
    }

    void check()
    {
        float range = 30.0f;
        float closestDistance = float.MaxValue;
        foreach (GameObject obj in spawn)
        {
            float distance = Vector3.Distance(obj.transform.position, position);
            if (distance < closestDistance && distance <= range) {
                closestDistance = distance;
                Debug.Log(closestDistance);
                closestSpawn = obj;
            }
        }
        //loop through all spawn points to find closest spawn point
    }
}
