using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{

    public Animator playerAnim;
    public Animator bottleAnim;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Found artifact");
            playerAnim.SetBool("isWalking", false);
            playerAnim.SetBool("isCollecting", true);
            bottleAnim.SetBool("isTriggered", true);
            GameObject.FindWithTag("Player").GetComponent<CharController>().enabled = false;
        }
    }
}
