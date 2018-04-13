using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{

    public Animator playerAnim;
    public Animator artifactAnim;

    public GameObject panel;

    public static int artifactCounter = 0;

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
            artifactCounter++;
            Debug.Log(artifactCounter);

            playerAnim.SetBool("isWalking", false);
            playerAnim.SetBool("isCollecting", true);
            artifactAnim.SetBool("isTriggered", true);
            GameObject.FindWithTag("Player").GetComponent<CharController>().enabled = false;

            StartCoroutine(wait());

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
        panel.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<CharController>().enabled = true;
        playerAnim.SetBool("isCollecting", false);
        gameObject.SetActive(false);
    }
}
