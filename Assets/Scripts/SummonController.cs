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
                summonBridge();
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            if (closestSpawn.tag == "BigB_Portal")
            {
                summonBigBridge();
            }
        }
        //SUMMON STAIRS
        else if (Input.GetKeyDown(KeyCode.K))
        {
            if (closestSpawn.tag == "Stairs_Portal")
            {
                Quaternion rotation = Quaternion.Euler(-90, 180, 0);
                summonStairs(rotation);
            }
            else if (closestSpawn.tag == "Stairs_PortalL")
            {
                Quaternion rotation = Quaternion.Euler(-90, 270, 0);
                summonStairs(rotation);
            }
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            bool isRotated = false;
            // Stairs and Raised Portal
            if (closestSpawn.tag == "Stairs_Portal")
            {
                Quaternion rotation = Quaternion.Euler(-90, 90, 0);
                summonPortal(rotation, isRotated);
            } else if (closestSpawn.tag == "Stairs_PortalL")
            {
                isRotated = true;
                Quaternion rotation = Quaternion.Euler(-90, 0, 0);
                summonPortal(rotation, isRotated);
            }
        }
    }

    void check(){
        float range = 30.0f;
        float closestDistance = float.MaxValue;
        foreach (GameObject obj in spawn)
        {
            float distance = Vector3.Distance(obj.transform.position, position);
            if (distance < closestDistance && distance <= range) {
                closestDistance = distance;
                //Debug.Log(closestDistance);
                closestSpawn = obj;
            }
        }
        //loop through all spawn points to find closest spawn point
    }

    void summonStairs(Quaternion rotation)
    {
        GameObject clone;
        Debug.Log("stairs");
        Vector3 stairsLoc = closestSpawn.transform.position;
        clone = Instantiate(stairs, stairsLoc, rotation);
        clone.SetActive(true);
    }

    void summonBridge()
    {
        GameObject clone;
        Debug.Log("bridge only");
        Vector3 bridgeLoc = closestSpawn.transform.position;
        clone = Instantiate(bridge, bridgeLoc, Quaternion.Euler(-90, 0, 0));
        clone.SetActive(true);
    }

    void summonBigBridge()
    {
        GameObject clone;
        Debug.Log("big bridge");
        Vector3 bigBridgeLoc = closestSpawn.transform.position;
        bigBridgeLoc.y += 4;
        clone = Instantiate(bigBridge, bigBridgeLoc, Quaternion.Euler(-90, 180, 0));
        clone.SetActive(true);
    }

    void summonPortal(Quaternion rotation, bool isRotated)
    {
        GameObject clone1, clone2;
        Debug.Log("raised portal");

        //portal enter
        Vector3 portalEnterLoc = closestSpawn.transform.position;
        Vector3 portalExitLoc = closestSpawn.transform.position;
        if (isRotated)
        {
            portalEnterLoc.z += 11.0f;
            portalEnterLoc.y += 2.5f;
            portalExitLoc.z -= 12.0f;
            portalExitLoc.y += 11.0f;
        } else
        {
            portalEnterLoc.x -= 11.0f;
            portalEnterLoc.y += 2.0f;
            portalExitLoc.x += 11.0f;
            portalExitLoc.y += 10.5f;
        }
        clone1 = Instantiate(portalEnter, portalEnterLoc, rotation);
        clone1.SetActive(true);
  
        clone2 = Instantiate(portalExit, portalExitLoc, rotation);
        clone2.SetActive(true);

        //TELEPORT
        float distEnter = Vector3.Distance(portalEnterLoc, position);
        float distExit = Vector3.Distance(portalExitLoc, position);
        if (distEnter < distExit)
        {
            transform.position = portalExitLoc;
        }
        else
        {
            transform.position = portalEnterLoc;
        }
    }
}
